
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
        var p1 = svc.AddPatient( new Patient {
            Firstname = "Joe",
            Surname = "Bloggs",
            Email = "joe@mail.com",
            NationalInsuranceNo = "12343"
            //  ....
        });   

        var p2 = svc.AddPatient( new Patient {
            Firstname = "Fred",
            Surname = "Bloggs",
            Email = "Fred@mail.com",
            NationalInsuranceNo = "45678"
            // ....
        });  

            var c1 = svc.AddCarer( new Carer {
            Firstname = "Mickey",
            Surname = "Mouse",
            EmailAddress = "Mickey@mail.com",
            NationalInsuranceNo = "456123"
        
        // add other dummy data here
        
    }); 
}
}

