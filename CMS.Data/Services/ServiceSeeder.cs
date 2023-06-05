
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
            DOB = new DateTime (1945,03,03),
            Email = "joe@mail.com",
            NationalInsuranceNo = "NR12345C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details",
            PhotoUrl = "/images/Caregiver.jpg",
            //  ....
        });  
        svc.AddPatient(p); 

        var p2 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Fred",
            Surname = "Bloggs",
            DOB = new DateTime (1946,02,04),
            Email = "Fred@mail.com",
            NationalInsuranceNo = "NR23456C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            MobileNumber = "01234567892",
            HomeNumber = "02830303031",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        });
         svc.AddPatient(p2);

            var p3 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Tom",
            Surname = "Bloggs",
            DOB = new DateTime (1947,05,28),
            Email = "Tom@mail.com",
            NationalInsuranceNo = "NR34567C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            MobileNumber = "01234567892",
            HomeNumber = "02830303031",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p3);  
 
            var p4 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Donald",
            Surname = "Bloggs",
            DOB = new DateTime (1948,05,28),
            Email = "Donald@mail.com",
            NationalInsuranceNo = "NR45678C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p4);

          var p5 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Mickey",
            Surname = "Bloggs",
            DOB = new DateTime (1947,05,28),
            Email = "Mickey@mail.com",
            NationalInsuranceNo = "NR56789C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p5);

          var p6 = svc.AddPatient( new Patient {
            Title = "Miss",
            Firstname = "Nancy",
            Surname = "Bloggs",
            DOB = new DateTime (1953,05,28),
            Email = "Nancy@mail.com",
            NationalInsuranceNo = "NR67891C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",

            PhotoUrl = "CMS/CMS.Web/wwwroot//images/Caregiver_with_seniorman_son.jpg"
            // ....
        }); 
         svc.AddPatient(p6);


           var p7 = svc.AddPatient( new Patient {
            Title = "Miss",
            Firstname = "Bunny",
            Surname = "Bloggs",
            DOB = new DateTime (1953,05,28),
            Email = "Bunny@mail.com",
            NationalInsuranceNo = "NR789123C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver_with_seniorman_son.jpg"
            // ....
        }); 
         svc.AddPatient(p7);

           var p8 = svc.AddPatient( new Patient {
            Title = "Miss",
            Firstname = "Nancy",
            Surname = "Bloggs",
            DOB = new DateTime (1950,05,28),
            Email = "Tom@mail.com",
            NationalInsuranceNo = "NR891012C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            // ....
        }); 
         svc.AddPatient(p8);

           var p9 = svc.AddPatient( new Patient {
            Title = "Miss",
            Firstname = "Minnie",
            Surname = "Bloggs",
            DOB = new DateTime (1953,05,28),
            Email = "Tom@mail.com",
            NationalInsuranceNo = "NR910234C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/Caregiver.jpg",
            // ....
        }); 
         svc.AddPatient(p9);

           var p10 = svc.AddPatient( new Patient {
            Title = "Miss",
            Firstname = "Mary",
            Surname = "Bloggs",
            DOB = new DateTime (1929,05,28),
            Email = "Mary@mail.com",
            NationalInsuranceNo = "NR101234C",
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl ="/images/Caregiver.jpg",
            // ....
        }); 
         svc.AddPatient(p10);

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

