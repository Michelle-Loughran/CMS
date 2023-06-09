using System.ComponentModel.DataAnnotations;
using CMS.Data.Models;

namespace CMS.Web.Models
{
    public class CreatePatientViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
      // To add patient details. 
        [Required]
        [StringLength(20, ErrorMessage = "First Name must be between 2 and 20 characters.", MinimumLength = 2)]
        [Display(Name="First Name")]
        public string Firstname {get; set;}

        [Required]
        [StringLength(20, ErrorMessage = "Surname must be between 2 and 20 characters.", MinimumLength = 2)]
        [Display(Name="Surname")]
        public string Surname {get; set;}

        [Required][StringLength(10, MinimumLength = 1)]
        public string NationalInsuranceNo { get; set; } = string.Empty;

        [Required][Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DateOfBirth(MinAge = 18, MaxAge = 120, ErrorMessage = "Patient must be beween 18 and 120 years old")]
        public DateTime DOB {get; set;}
        public int Age => (DateTime.Now - DOB).Days / 365;

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
        [Display(Name = "Select CareEvents")]
        public int CareEvents { get; set; }

        [Required]
        [EnumDataType(typeof(Condition))]
        [Display(Name = "Select Condition")]
        public Condition Conditions {get; set;}
        
        [Required]
        [Display(Name = "Select Family Member")]
        public FamilyMember FamilyMember {get; set;}

        [Required]
        [Display(Name = "Select Family")]
        public int FamilyMemberId { get; set;}
           
        public class DateOfBirthAttribute : ValidationAttribute
        {
            public int MinAge { get; set; }
            public int MaxAge { get; set; }

            public override bool IsValid(object value)
            {
                if (value == null)
                    return true;

                var val = (DateTime)value;

                if (val.AddMonths(MinAge) > DateTime.Now)
                    return false;

                return (val.AddYears(MaxAge) > DateTime.Now);
            }
        }
    }
}   
