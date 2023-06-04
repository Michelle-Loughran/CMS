using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CMS.Data.Models;

namespace CMS.Web.Models
{
    public class PatientIndexViewModel
    {
        
        public string Title { get; set; } = string.Empty;
      //  patient details. 
        public string Firstname {get; set;}
        public string Surname {get; set;}
        public string NationalInsuranceNo { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB {get; set;}
        public double Age => (DateTime.Now - DOB).Days / 365.242199;
        public string DOBFormat => DOB.ToLongDateString();
        public string Street { get; set; } = string.Empty;       
        public string Town { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string HomeNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string GP { get; set; } = string.Empty;
        public string SocialWorker { get; set; } = string.Empty;
        public string CarePlan { get; set; }
        public string PhotoUrl {get; set;}
        public Condition Condition {get; set;}
        public FamilyMember Families {get; set;}
        public int FamilyId { get; set; }
            // a set of care events 
        public List<PatientCareEvent> CareEvents { get; set; }

        // a set of patient conditions
        public List<PatientCondition> Conditions { get; set; }

        // a set of patient family members
        public List<PatientFamily>  Family { get; set; }
    }

    }


 