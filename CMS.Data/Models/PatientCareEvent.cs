namespace CMS.Data.Models;

public class PatientCareEvent 
{
    public int Id { get; set; }

    public DateTime DateTimeOfEvent { get; set; }

    // copy of Patient.CarePlan made when Event created
    public string CarePlan { get; set; } 

    // Notes documenting completion of Careplan
    public string Notes { get; set; } 

    // relationships

    // the patient the care event is performed on
    public int PatientId { get; set; }   
    public Patient Patient { get; set; }

    // the carer who performed the care event
    public int CarerId { get; set; }
    public Carer Carer { get; set; }
    // the Patient Family members
    public int PatientFamily  { get; set; }
    public PatientFamily PatientFamilies { get; set; } 

}

