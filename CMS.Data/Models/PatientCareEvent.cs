using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Models;

public class PatientCareEvent 
{
    public int Id { get; set; }

    public DateTime DateTimeOfEvent { get; set; }

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Issues { get; set; }
    [Range(0, 10, ErrorMessage = "The number of calls shoould be between 1 and 10")]
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

