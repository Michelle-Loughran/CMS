using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMS.Data.Services;
using CMS.Data.Models;

namespace CMS.Web.Controllers
{
    [Route("[controller]")]
    public class CarerController : BaseController
    {
        private readonly IPatientService svc;

    public CarerController()
    {
        svc = new PatientServiceDb();
    }

    // GET /family
    public IActionResult Index()
    {
        // load carers using service and pass to view
        var carers = svc.GetAllCarers();
        
        return View(carers);
    }

    // GET /carers/details/{id}
    public IActionResult Details(int id)
    {
        var carers = svc.GetCarer(id);
      
        // check if carers is null and alert/redirect 
        if (carers is null) {
                Alert("Carer Does not Exist", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }

        return View(carers);
    }

    // GET: /carers/create   
    public IActionResult Create()
    {
        // display blank form to create a carer
        return View();
    }

    // POST /carers/create
    //[ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Create(Carer c)
    {   
      
        // complete POST action to add patient
        if (ModelState.IsValid)
        {
            // call service Addpatient method using data in s
            var carer = svc.AddCarer(c);
            if (carer is null) 
            {
                Alert("Issue creating the carer", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), new { Id = carer.Id});   
        }
        
        // redisplay the form for editing as there are validation errors
        return View(c);
    }

    // GET /Carer/edit/{id}
    public IActionResult Edit(int id)
    {
        // load the Carer using the service
        var carer = svc.GetCarer(id);

        // check if family is null and Alert/Redirect
        if (carer is null)
        {
            Alert("Carer not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }  

        // pass patient to view for editing
        return View(carer);
    }

    // POST /patient/edit/{id}
    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Edit(int id, Carer c)
    {       
        // complete POST action to save family member changes
        if (ModelState.IsValid)
        {            
            var carer = svc.UpdateCarer(c);
            if (carer is null) 
            {
                Alert("Issue updating the carer", AlertType.warning);
            }

            // redirect back to view the patient details
            return RedirectToAction(nameof(Details), new { Id = c.Id });
        }

        // redisplay the form for editing as validation errors
        return View(c);
    }

    // GET / carer/delete/{id}   
    public IActionResult Delete(int id)
    {
        // load the carer using the service
        var carer = svc.GetCarer(id);
        // check the returned carer is not null and if so return NotFound()
        if (carer == null)
        {
            Alert("Carer not found", AlertType.warning);
            return RedirectToAction(nameof(Index));
        }     
        
        // pass carer to view for deletion confirmation
        return View(carer);
    }

    // POST /carer/delete/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]   
    public IActionResult DeleteConfirm(int id)
    {
        // delete patient via service
        var deleted = svc.DeleteCarer(id);
        if (deleted)
        {
            Alert("Carer deleted", AlertType.success);            
        }
        else
        {
            Alert("carercould not  be deleted", AlertType.warning);           
        }
        
        // redirect to the index view
        return RedirectToAction(nameof(Index));
    }

}
}
