using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CMS.Data.Models;

public class Patient

{    // primary key
    [Required][Column("Patient_Id")]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    [Required][StringLength(80, MinimumLength = 1)]
    public string Firstname { get; set; } = string.Empty;
     
    [Required][StringLength(80, MinimumLength = 1)]
    public string Surname { get; set; } = string.Empty;

    [Required][StringLength(10, MinimumLength = 1)]
    public string NationalInsuranceNo { get; set; } = string.Empty;

    [Display(Name = "DOB")][DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime DOB { get; set; } 
        // readonly
    public int Age => (DateTime.Now - DOB).Days /365;
    
    [Required][StringLength(50, MinimumLength = 1)]
    public string Street { get; set; } = string.Empty;
              
    [Required][StringLength(50, MinimumLength = 1)]
    public string Town { get; set; } = string.Empty;
    
    [Required][StringLength(50, MinimumLength = 1)]
    public string County { get; set; } = string.Empty;

    [Required][StringLength(8, MinimumLength = 3)]
    public string Postcode { get; set; } = string.Empty;

    [Url]    
    public  string PhotoUrl { get; set; }

    [Required][StringLength(11)]
    public string MobileNumber { get; set; } = string.Empty;

     [StringLength(11)]
    public string HomeNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

   [Required][StringLength(80, MinimumLength = 3)]
    public string GP { get; set; } = string.Empty;
    [Required][StringLength(80, MinimumLength = 3)]
    public string SocialWorker { get; set; } = string.Empty;

    public string CarePlan { get; set; }
   
    // Relationships

    // a set of care events 
    public List<PatientCareEvent> CareEvents { get; set; }

    // a set of patient conditions
    public List<PatientCondition> Conditions { get; set; }

    // a set of patient family members
    public List<PatientFamily>  Families { get; set; }
    public List<Carer>  Carers { get; set; }
    
}
