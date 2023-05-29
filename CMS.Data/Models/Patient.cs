using System.ComponentModel.DataAnnotations;

namespace CMS.Data.Models;

public class Patient
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string NationalInsuranceNo { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Firstname { get; set; } = string.Empty;
     
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Surname { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Street { get; set; } = string.Empty;
              
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Town { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string County { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Country { get; set; } = string.Empty;
 
    public string Postcode { get; set; } = string.Empty;

    
    public  string PhotoUrl { get; set; } = string.Empty;

    [Required]
    public string MobileNumber { get; set; } = string.Empty;

    [Required]
    public string HomeNumber { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string GP { get; set; } = string.Empty;

    public string SocialWorker { get; set; } = string.Empty;

    public string CarePlan { get; set; }


    // readonly
    public double Age => (DateTime.Now - DOB).Days / 365.242199;
   
    // Relationships

    // a set of care events 
    public List<PatientCareEvent> CareEvents { get; set; }

    // a set of patient conditions
    public List<PatientCondition> Conditions { get; set; }

    // a set of patient family members
    public List<PatientFamily>  Family { get; set; }
}
