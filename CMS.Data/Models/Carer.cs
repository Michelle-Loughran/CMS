using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CMS.Data.Models;
public class Carer
{ [Required][Column("Carer_Id")]
    public int Id { get; set; }
    public string Title  {get; set; } = string.Empty;

    [Required][StringLength(80, MinimumLength = 1)]
    public string Firstname { get; set; }= string.Empty;

    [Required][StringLength(80, MinimumLength = 1)]
    public string Surname { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
   public int Age => (DateTime.Now - DOB).Days / 365;

     [Required][StringLength(80, MinimumLength = 1)]
    public string NationalInsuranceNo { get; set; } = string.Empty;
    public bool DBSCheck { get; set; }

    [Required][StringLength(80, MinimumLength = 1)]
    public string EmailAddress { get; set; } = string.Empty;
    [Required][StringLength(80, MinimumLength = 1)]
    public string Street { get; set; } = string.Empty;
    [Required][StringLength(80, MinimumLength = 1)]
    public string Town { get; set; } = string.Empty;
    [Required][StringLength(80, MinimumLength = 1)]
    public string County { get; set; } = string.Empty;
    [Required][StringLength(8, MinimumLength = 3)]
    public string Postcode { get; set; } = string.Empty;
    [Required][StringLength(11)]
    public string MobileNumber { get; set; } = string.Empty;
    [Required]
    public string HomeNumber { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
    [Url]    
    public  string PhotoUrl { get; set; }
   
    // ...

    // Relationships

    // a carer has a login account
    // public int UserId { get; set; }
    // public User User { get; set; } 

    // navigation property
    public int PatientId { get; set; }

    // a carer performs many patient care events on Patient
    public List<PatientCareEvent> PatientCareEvents { get; set;} = new List<PatientCareEvent>();

}




