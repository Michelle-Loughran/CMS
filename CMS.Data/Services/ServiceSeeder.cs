
using CMS.Data.Models;

namespace CMS.Data.Services;
public static class ServiceSeeder
{
    // use this class to seed the database with dummy test data using an IPatientService 
    public static void Seed(IPatientService svc)
    {
        // wipe and recreate the database
        svc.Initialise();

        // add patient data
        var p = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Joe",
            Surname = "Bloggs",
            // DOB = "24.05.1945",
            Email = "joe@mail.com",
            NationalInsuranceNo = "12343",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Country = "Northern Ireland",
            Postcode = "BT34 2PH",
            PhotoUrl = "CMS.Web/wwwroot/images/Caregiver_with_seniorman_son.jpg"
            //  ....
        });  
        svc.AddPatient(p); 

        var p2 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Fred",
            Surname = "Bloggs",
            Email = "Fred@mail.com",
            NationalInsuranceNo = "45678",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Country = "Northern Ireland",
            Postcode = "BT34 2PH",
            PhotoUrl = "CMS.Web/wwwroot/images/Caregiver_with_seniorman_son.jpg"
            // ....
        });
         svc.AddPatient(p2);

            var p3 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Tom",
            Surname = "Bloggs",
            Email = "Tom@mail.com",
            NationalInsuranceNo = "45678",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Country = "Northern Ireland",
            Postcode = "BT34 2PH",
            PhotoUrl = "CMS.Web/wwwroot/images/Caregiver_with_seniorman_son.jpg"
            // ....
        }); 
         svc.AddPatient(p3);  

            var c1 = svc.AddCarer( new Carer {
            Firstname = "Mickey",
            Surname = "Mouse",
            EmailAddress = "Mickey@mail.com",
            NationalInsuranceNo = "456123"
        
        // add other dummy data here
        
    }); 
}
}

