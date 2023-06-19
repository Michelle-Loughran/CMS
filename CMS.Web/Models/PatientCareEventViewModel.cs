using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  CMS.Data.Models;

namespace CMS.Web.Models;


    public class PatientCareEventViewModel
    {
     public int Id { get; set; }

    public DateTime DateTimeOfEvent { get; set; }

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Issues { get; set; }
    [Range(0, 10, ErrorMessage = "The number of calls should be between 1 and 10")]
    public int Calls { get; set; }

    public TimeOnly Call1 { get; set; }

    // relationships

    // the patient the care event is performed on
    public int PatientId { get; set; }

    public Patient Patient { get; set; }

    // the carer who performed the care event
    public int CarerId { get; set; }
    public Carer Carer { get; set; }

    }
   