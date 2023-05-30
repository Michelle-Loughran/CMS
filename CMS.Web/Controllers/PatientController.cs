using Microsoft.AspNetCore.Mvc;
 using System;
using System.Collections.Generic;
 using System.Diagnostics;
 using System.Linq;
 using System.Threading.Tasks;
 using Microsoft.Extensions.Logging;

using CMS.Data.Services;
using CMS.Data.Models;
using CMS.Web.Models;

namespace CMS.Web.Controllers;

public class PatientController : BaseController
{
    private readonly IPatientService svc;

    public PatientController()
    
    {
        svc = new PatientServiceDb();
    }

    // GET /patient
    public IActionResult Index(string patientSearch)
    {
        // load patients using service and pass to view
        var patients = svc.GetAllPatients(patientSearch);
        
        return View(patients);
    }

    // GET /patient/details/{id}
    public IActionResult Details(int id)
    {
        var patient = svc.GetPatientById(id);
      
        // check if patient is null and alert/redirect 
        if (patient is null) {
            Alert("Patient Does not Exist", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        return View(patient);
    }

    // GET: /patient/create   
    public IActionResult Create()
    {
        // display blank form to create a patient
        var p = new Patient();
        //return the new patient to the view
        return View(p);
    }

    // POST /patient/create
    //[ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Create(Patient p)
    {   
      
        // complete POST action to add patient
        if (ModelState.IsValid)
        {
            // call service Addpatient method using data in p
            var patient = svc.AddPatient(p);
            if (patient is null) 
            {
                Alert("Issue creating the patient", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), new { Id = patient.Id});   
        }
        
        // redisplay the form for editing as there are validation errors
        return View(p);
    }

    // GET /patient/edit/{id}
    public IActionResult Edit(int id)
    {
        // load the patient using the service
        var patient = svc.GetPatientById(id);

        // check if patient is null and Alert/Redirect
        if (patient is null)
        {
            Alert("Patient not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }  

        // pass patient to view for editing
        return View(patient);
    }

    // POST /patient/edit/{id}
    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Edit(int id, Patient p)
    {       
        // complete POST action to save patient changes
        if (ModelState.IsValid)
        {            
            var patient = svc.UpdatePatient(p);
            if (patient is null) 
            {
                Alert("Issue updating the patient", AlertType.warning);
            }

            // redirect back to view the patient details
            return RedirectToAction(nameof(Details), new { Id = p.Id });
        }

        // redisplay the form for editing as validation errors
        return View(p);
    }

    // GET / patient/delete/{id}   
    public IActionResult Delete(int id)
    {
        // load the patient using the service
        var patient = svc.GetPatientById(id);
        // check the returned patient is not null and if so return NotFound()
        if (patient == null)
        {
            Alert("Patient not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }     
        
        // pass patient to view for deletion confirmation
        return View(patient);
    }

    // POST /patient/delete/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]   
    public IActionResult DeleteConfirm(int id)
    {
        // delete patient via service
        var deleted = svc.DeletePatient(id);
        if (deleted)
        {
            Alert("patient deleted", AlertType.success);            
        }
        else
        {
            Alert("patient could not  be deleted", AlertType.warning);           
        }
        
        // redirect to the index view
        return RedirectToAction(nameof(Index));
    }

}
