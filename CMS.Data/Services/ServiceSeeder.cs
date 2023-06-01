
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
            DOB = new DateTime (1945/03/03),
            Email = "joe@mail.com",
            NationalInsuranceNo = "12343",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver_with_seniorman_son.jpg"
            
            //  ....
        });  
        svc.AddPatient(p); 

        var p2 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Fred",
            Surname = "Bloggs",
            DOB = new DateTime (1945/02/04),
            Email = "Fred@mail.com",
            NationalInsuranceNo = "45678",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver_with_seniorman_son.jpg"
            // ....
        });
         svc.AddPatient(p2);

            var p3 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Tom",
            Surname = "Bloggs",
            DOB = new DateTime (1947/05/28),
            Email = "Tom@mail.com",
            NationalInsuranceNo = "45678",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver_with_seniorman_son.jpg"
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
    svc.AddCarer(c1);  
}
}

