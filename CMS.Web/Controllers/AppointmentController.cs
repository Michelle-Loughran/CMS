using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CMS.Data.Entities;
using CMS.Data.Services;
using Microsoft.AspNetCore.Authorization;
using CMS.Data.Security;
using CMS.Web.Models.User;
using System;


namespace CMS.Web.Controllers
{    [Authorize(Roles="carer")]
    public class AppointmentController : BaseController
    {
        private readonly IPatientService svc;

        public AppointmentController()
        {
            svc = new PatientServiceDb();
        }

        public IActionResult Index()
        {
           IList<Appointment> appointments;
        if (User.HasOneOfRoles("carer, manager")) 
        {
            appointments = svc.GetUserAppointments(User.GetSignedInUserId());
        }
        else{
            // load appointments using service and pass to view
            appointments = svc.GetAllAppointments();
        }
        
        return View(appointments);
    }
     // GET /patient/details/{id}
    public IActionResult PatientDetails(int id)
    { 
        // retrieve the patient with specified id from the service
        var patient = svc.GetPatientById(id);
      
        // check if patient is null and alert/redirect 
        if (patient == null) {
            Alert("Patient Does not Exist", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }
       // GET: /Patient care-event/create/patientId   
        public IActionResult CreateCareEvent(int id)
        {
            var patient = svc.GetPatientById(id);
            if (patient is null)
            {
                Alert("Patient does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Appointment");
            }

            // int userId =  User.GetSignedInUserId();
            int carerId = svc.Get(id);
            if (carerId is null)
            {
                Alert("Carer does not exist", AlertType.warning);
                return RedirectToAction(nameof(Index), "Appointment");
            }
            // var carer = svc.GetCarerById(id);
            if (carerId is null)
            {
                Alert("Carer does not exist", AlertType.warning);
                return RedirectToAction(nameof(PatientDetails), "Appointment", new { Id = id });
            }        

            // display blank form to create a carer
            var pce = new PatientCareEvent
            {
                Patient = patient,
                PatientId = patient.Id,                
                Carer = carer,
                CarerId = carer.Id,
                DateTimeOfEvent = DateTime.Now,
                Issues = "record visit activity here...",
                
            };

            //return the new Patient care-event to the view
            return View(pce);
        }
         // POST /carers/create
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateCareEvent(int patientId, [Bind("DateTimeOfEvent, CarePlan, Issues, PatientId, CarerId")] PatientCareEvent pce)
        {    // Check patient care event being passed in has Id preset before adding properties
            if (pce == null)
            {
                Alert($"Patient Care Event Does not exist {pce.Id}", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            // complete POST action to add patient care event to database
            if (ModelState.IsValid)
            {
                // call service Addpatientcareevent method using data in pce
                svc.AddPatientCareEvent(pce);

                Alert("Patient-care-event created successfully!", AlertType.warning);

                return RedirectToAction(nameof(PatientDetails), "Appointment", new { Id = pce.PatientId });
            }

            // redisplay the form for editing as there are validation errors
            return View(pce);
        }
         // GET /PatientCareEvent/Delete/{id}
        public IActionResult Delete(int id)
        {
            var pce = svc.GetPatientCareEventById(id);

            // check if patientcare-events is null and alert/redirect 
            if (pce is null)
            {
                Alert("Patient Care Event Does not Exist", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(pce);
        }
         // POST /PatientCareEvent/Delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var ce = svc.GetPatientCareEventById(id);
            if (ce is null) 
            {
                Alert("Patient Care Event Could not be deleted", AlertType.warning); 
            }
           svc.DeletePatientCareEvent(id);           

           return RedirectToAction("PatientDetails", "Appointment", new { id = ce.PatientId });
        }
}
}



