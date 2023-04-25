using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Models;
public class Carer
{
    public int Id { get; set; }
    public string Title  {get; set; } = string.Empty;
    public string Firstname { get; set; }= string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public int Age => (DateTime.Now - DOB).Days / 365;
    public string NationalInsuranceNo { get; set; } = string.Empty;
    public bool DBSCheck { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
    [Required]
    public string MobileNumber { get; set; } = string.Empty;
    [Required]
    public string HomeNumber { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
   
    // ...

    // Relationships

    // a carer has a login account
    // public int UserId { get; set; }
    // public User User { get; set; } // navigation property

    // a carer performs many patient care events
    public List<PatientCareEvent> PatientCareEvents { get; set;} = new List<PatientCareEvent>();
}




