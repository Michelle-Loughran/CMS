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
      // To add patient details. 
    [Required]
        [StringLength(20, ErrorMessage = "First Name must be between 2 and 20 charaters.", MinimumLength = 2)]
        [Display(Name="First Name")]
        public string FirstName {get; set;}

        [Required]
        [StringLength(20, ErrorMessage = "Surname must be between 2 and 20 charaters.", MinimumLength = 2)]
        [Display(Name="Surname")]
        public string Surname {get; set;}

        [Required]
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB {get; set;}

        [Required]
        [Url]
        public string Photo {get; set;}

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
