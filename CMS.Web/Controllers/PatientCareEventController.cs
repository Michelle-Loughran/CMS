using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Data.Models;
using CMS.Data.Services;

namespace CMS.Web.Controllers
{    
    public class PatientCareEventController : BaseController
    {
        private readonly IPatientService svc;

        public PatientCareEventController()
        {
           svc = new PatientServiceDb();
        }

        public IActionResult Index()
        {
        // load patientcare-events using service and pass to view
        var pce = svc.GetAllPatientCareEvents();

            return View(pce);
        }

        // GET /Patient Care Event/details/{id}
    public IActionResult Details(int id)
    {
        var pce = svc.GetPatientCareEventById(id);
      
        // check if patientcare-events is null and alert/redirect 
        if (pce is null) {
                Alert("Patient Care Event Does not Exist", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        return View(pce);
    }

     // GET: /Patient care-event/create   
    public IActionResult Create()
    {
        // display blank form to create a carer
        var pce = new PatientCareEvent();
        //return the new Patient care-event to the view
        return View(pce);
    }

 // POST /carers/create
    //[ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Create([Bind("DateTimeOfEvent, CarePlan, Issues, Calls, Call1,  PatientId, CarerId")] PatientCareEvent pce)
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
             svc.AddPatientCareEvent(pce.DateTimeOfEvent,pce.CarePlan,pce.Issues,pce.Calls, pce.Call1, pce.PatientId, pce.CarerId);

                Alert("Patient-care-event created successfully!", AlertType.warning);
            
            return RedirectToAction(nameof(Details), new { Id = pce.Id});   
        }
        
        // redisplay the form for editing as there are validation errors
        return View(pce);
    }



    }
}
