using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data.Models;

namespace CMS.Web.Models
{
    public class CreatePatientViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;
      // To add patient details. 
        [Required]
        [StringLength(20, ErrorMessage = "First Name must be between 2 and 20 charaters.", MinimumLength = 2)]
        [Display(Name="First Name")]
        public string Firstname {get; set;}

        [Required]
        [StringLength(20, ErrorMessage = "Surname must be between 2 and 20 charaters.", MinimumLength = 2)]
        [Display(Name="Surname")]
        public string Surname {get; set;}
        [Required][StringLength(10, MinimumLength = 1)]
        public string NationalInsuranceNo { get; set; } = string.Empty;
        [Required][Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB {get; set;}
        public double Age => (DateTime.Now - DOB).Days / 365.242199;

        [Required][StringLength(50, MinimumLength = 1)]
        public string Street { get; set; } = string.Empty;
                  
        [Required][StringLength(50, MinimumLength = 1)]
        public string Town { get; set; } = string.Empty;
        
        [Required][StringLength(50, MinimumLength = 1)]
        public string County { get; set; } = string.Empty;

        [Required][StringLength(8, MinimumLength = 3)]
        public string Postcode { get; set; } = string.Empty;
       [Required][StringLength(11)]
        public string MobileNumber { get; set; } = string.Empty;

        [StringLength(11)]
        public string HomeNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

      [Required][StringLength(8, MinimumLength = 3)]
        public string GP { get; set; } = string.Empty;
        [Required][StringLength(8, MinimumLength = 3)]
        public string SocialWorker { get; set; } = string.Empty;

       public string CarePlan { get; set; }
        [Required][Url]
        public string PhotoUrl {get; set;}

        [Required]
        [EnumDataType(typeof(Condition))]
        [Display(Name = "Select Condition")]
        public Condition Condition {get; set;}
        
        public FamilyMember Families {get; set;}

        [Required]
        [Display(Name = "Select Family")]
        public int FamilyId { get; set; }
    }
}   
