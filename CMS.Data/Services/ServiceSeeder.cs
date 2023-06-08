
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
            NationalInsuranceNo = "NR12345C",
            DOB = new DateTime (1945,03,03),
            Street = "24 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/1.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "joe@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"

            //  ....
        });  
        svc.AddPatient(p); 

        var p2 = svc.AddPatient( new Patient {
            Title = "Mrs",
            Firstname = "Mary",
            Surname = "Bloggs",
            NationalInsuranceNo = "NR23456C",
            DOB = new DateTime (1946,02,04),
            Street = "25 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/2.jpg",
            MobileNumber = "01234567892",
            HomeNumber = "02830303031",
            Email = "Mary@mail.com",
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
            NationalInsuranceNo = "NR34567C",
            DOB = new DateTime (1947,05,28),
            Street = "26 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/3.jpg",
            MobileNumber = "01234567892",
            HomeNumber = "02830303031",
            Email = "Tom@mail.com",
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
            NationalInsuranceNo = "NR45678C",
            DOB = new DateTime (1948,05,28),
            Street = "27 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/4.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Donald@mail.com",
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
            NationalInsuranceNo = "NR56789C",
            DOB = new DateTime (1947,05,28),    
            Street = "28 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/5.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Mickey@mail.com",
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
            NationalInsuranceNo = "NR67891C",
            DOB = new DateTime (1953,05,28),          
            Street = "29 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/6.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Nancy@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p6);


           var p7 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Brian",
            Surname = "Bloggs",
            NationalInsuranceNo = "NR789123C",
            DOB = new DateTime (1953,05,28),
            Street = "30 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/7.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Brian@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p7);

           var p8 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Niall",
            Surname = "Bloggs",
            NationalInsuranceNo = "NR891012C",
            DOB = new DateTime (1950,05,28),
            Street = "31 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/8.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Niall@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p8);

           var p9 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "Michael",
            Surname = "Bloggs",
            NationalInsuranceNo = "NR910234C",
            DOB = new DateTime (1953,05,28),
            Street = "32 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl = "/images/9.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Michael@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p9);

           var p10 = svc.AddPatient( new Patient {
            Title = "Mr",
            Firstname = "John",
            Surname = "Bloggs",
            NationalInsuranceNo = "NR101234C",
            DOB = new DateTime (1929,05,28),
            Street = "33 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            PhotoUrl ="/images/10.jpg",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Email = "Mary@mail.com",
            GP = "Dr A Blagg",
            SocialWorker = " Dr Minnie Mouse",
            CarePlan = "See File for details"
            // ....
        }); 
         svc.AddPatient(p10);

            var c1 = svc.AddCarer( new Carer {
            Title = "Mr",
            Firstname = "Michael",
            Surname = "Hegarty",
            DOB = new DateTime (1977,05,28), 
            NationalInsuranceNo = "NR456123D",
            DBSCheck= true,
            EmailAddress = "Mickey@mail.com",
            Street = "34 Warren Hill",
            Town = "Newry",
            County = "Down",
            Postcode = "BT34 2PH",
            MobileNumber = "01234567891",
            HomeNumber = "02830303030",
            Qualifications = "",
            PhotoUrl ="/images/Carer1.jpg"
        // add other dummy data here     
    }); 
    svc.AddCarer(c1);  
}
}

