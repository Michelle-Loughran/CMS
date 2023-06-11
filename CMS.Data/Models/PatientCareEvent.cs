

namespace CMS.Data.Models;

public class PatientCareEvent 
{
    public int Id { get; set; }

    public DateTime DateTimeOfEvent { get; set; }

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Issues { get; set; }

    public int Calls { get; set; }

    public TimeOnly Call1 { get; set; }
    public TimeOnly Call2 { get; set; }
    public TimeOnly Call3 { get; set; }
    public TimeOnly Call4 { get; set; }
    public TimeOnly Call5 { get; set; }

    // relationships

    // the patient the care event is performed on
    public int PatientId { get; set; }

    public Patient Patient { get; set; }

    // the carer who performed the care event
    public int CarerId { get; set; }
    public Carer Carer { get; set; }


}

