using Xunit;

using CMS.Data.Services;
using CMS.Data.Models;

namespace CMS.Test;

public class ServiceTests
{

    private readonly IPatientService svc;
    public ServiceTests()
    {
        svc = new PatientServiceDb();
        svc.Initialise();
    }

    [Fact]
    public void GetAllPatients_WhenNone_ShouldReturnZero()
    {
        // arrange

        // act
        var patients = svc.GetAllPatients();

        // assert
        Assert.Equal(0, patients.Count);
    }

    [Fact]
    public void AddPatient_WhenValid_ShouldReturnPatient()
    {
        // arrange

        // act add patient to database
        var patient = svc.AddPatient(new Patient
        {
            Title = " Mr ",
            Firstname = "Joe",
            Surname = "Bloggs",
            NationalInsuranceNo = "BR128734B",
            DOB = new DateTime(1947, 03, 03),
            Email = "joe@mail.com",
            Street = " 27 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "07892891702",
            HomeNumber = "028302515",
            GP = " Dr R Campbell",
            SocialWorker = "Cathy Burke ",
            CarePlan = "Get dressed and washed"
            // ....
        });

        // assert
        Assert.NotNull(patient);
        Assert.Equal("Joe", patient.Firstname);
        Assert.Equal("Bloggs", patient.Surname);
        Assert.Equal("joe@mail.com", patient.Email);
        Assert.Equal("BR128734B", patient.NationalInsuranceNo);
    }


    [Fact]
    public void GetPatient_WhenExists_ShouldReturnPatient()
    {
        // arrange
        var ap = svc.AddPatient(new Patient
        {
            Firstname = "John",
            Surname = "White",
            NationalInsuranceNo = " BR234567",
            DOB = new DateTime(1947, 09, 24),
            Email = "john@mail.com",
            Street = " 28 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567891",
            HomeNumber = "028301234",
            GP = " Dr R Campbell",
            SocialWorker = "Cathy Burke ",
            CarePlan = "Get dressed and washed"
            // ....
        });

        // act
        var patient = svc.GetPatientById(ap.Id);

        // assert -- TODO Check for other properties
        Assert.NotNull(patient);
        Assert.Equal(ap.Firstname, patient.Firstname);
        Assert.Equal(ap.Surname, patient.Surname);
        Assert.Equal(ap.DOB, patient.DOB);
        Assert.Equal(ap.NationalInsuranceNo, patient.NationalInsuranceNo);
        Assert.Equal(ap.Email, patient.Email);
        Assert.Equal(ap.Conditions, patient.Conditions);
        Assert.Equal(ap.MobileNumber, patient.MobileNumber);
    }

    [Fact]
    public void UpdatePatient_WhenExistsAndIsValid_ShouldReturnUpdatedPatient()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());

        // act == TODO - need to check for all properties except Id
        var updated = svc.UpdatePatient(new Patient
        {
            Id = p.Id,
            Firstname = p.Firstname,
            Surname = "Changed",
            NationalInsuranceNo = p.NationalInsuranceNo,
            DOB = p.DOB,
            Email = p.Email,
            Street = p.Street,
            Town = p.Town,
            County = p.County,
            Postcode = p.Postcode,
            MobileNumber = p.MobileNumber,
            HomeNumber = p.HomeNumber,
            GP = p.GP,
            SocialWorker = p.SocialWorker,
            CarePlan = p.CarePlan
            // ....
        });

        // assert
        Assert.NotNull(updated);
        Assert.Equal("Changed", updated.Surname);
    }

    [Fact]
    public void UpdatePatient_WhenDuplicateNationalInsuranceNo_ShouldReturnNull()
    {
        // arrange
        var p1 = svc.AddPatient(new Patient
        {
            Firstname = "Joe",
            Surname = "Bloggs",
            Email = "joe@mail.com",
            NationalInsuranceNo = "1234"
            // ...
        });
        var p2 = svc.AddPatient(new Patient
        {
            Firstname = "Fred",
            Surname = "Bloggs",
            Email = "Fred@mail.com",
            NationalInsuranceNo = "34565"
            // ...
        });

        // act
        var updated = svc.UpdatePatient(new Patient
        {
            Id = p1.Id,
            Firstname = p1.Firstname,
            Surname = p1.Surname,
            Email = p1.Email,
            NationalInsuranceNo = p2.NationalInsuranceNo
            // ....
        });

        // assert
        Assert.Null(updated);
    }

    [Fact]
    public void DeletePatient_WhenNotExists_ShouldReturnFalse()
    {
        // arrange     

        // act
        var success = svc.DeletePatient(1);

        // assert
        Assert.False(success);
    }

    [Fact]
    public void DeletePatient_WhenExists_ShouldReturnTrue()
    {
        // arrange
        var dummy = svc.AddPatient(new Patient
        {
            Firstname = "Joe",
            Surname = "Bloggs",
            // ....
        });

        // act
        var success = svc.DeletePatient(dummy.Id);

        // assert
        Assert.True(success);
    }

    //========================Carer Tests========================================
    [Fact]
    public void GetAllCarers_WhenNone_ShouldReturnZero()
    {
        // arrange

        // act
        var carers = svc.GetAllCarers();
        // assert
        Assert.Equal(0, carers.Count);
    }

    [Fact]
    public void AddCarer_WhenValid_ShouldReturnCarer()
    {
        // arrange

        // act
        var carer = svc.AddCarer(new Carer
        {
            Title = " Mr ",
            Firstname = "Donald",
            Surname = "Duck",
            NationalInsuranceNo = "CD123456",
            DOB = new DateTime(1968, 03, 04),
            EmailAddress = "Donald@mail.com",
            Street = "28 Warren Hill",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567898",
            HomeNumber = "028302515",
            Qualifications = "BTEC Level III Social Healthcare"

            // ....
        });
        // assert -- TODO Check for all properties (except Id)
        Assert.NotNull(carer);
        Assert.Equal("Donald", carer.Firstname);
        Assert.Equal("Duck", carer.Surname);
        Assert.Equal("Donald@mail.com", carer.EmailAddress);
        Assert.Equal("CD123456", carer.NationalInsuranceNo);
        Assert.Equal("28 Warren Hill", carer.Street);
        Assert.Equal("Newry", carer.Town);
        Assert.Equal(" Down", carer.County);
        Assert.Equal("01234567898", carer.MobileNumber);
    }
  
    [Fact]
    public void GetCarer_WhenExists_ShouldReturnCarer()
    {
        // arrange
        var dummy = svc.AddCarer(new Carer
        {
            Firstname = "John",
            Surname = "White",
            NationalInsuranceNo = "BR234567",
            DOB = new DateTime(1947, 09, 24),
            EmailAddress = "john@mail.com",
            Street = " 28 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567891",
            HomeNumber = "028301234",

            // ....
        });

        // act
        var carer = svc.GetCarerById(dummy.Id);

        // assert
        Assert.NotNull(carer);
        Assert.Equal("BR234567", carer.NationalInsuranceNo);

    }

    [Fact]
    public void GetCarerByEmail_WhenValid_ShouldReturnCarer()
    {
        // arrange
        var c = svc.AddCarer(new Carer
        {
            Title = " Mr ",
            Firstname = "Minnie",
            Surname = "Mouse",
            NationalInsuranceNo = "CD987654321",
            DOB = new DateTime(1983, 03, 04),
            EmailAddress = "Minnie@mail.com",
            Street = " 30 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567898",
            HomeNumber = "028302515",
            Qualifications = "BTEC Level II Social Healthcare"
            // ....
        });

        // act
        var carer = svc.GetCarerByEmail(c.EmailAddress);

        // assert
        Assert.NotNull(carer);
        Assert.Equal("Minnie", carer.Firstname);
        Assert.Equal("Mouse", carer.Surname);
        Assert.Equal("Minnie@mail.com", carer.EmailAddress);
        Assert.Equal("CD987654321", carer.NationalInsuranceNo);
    }

    [Fact]
    public void UpdateCarer_WhenExistsAndIsValid_ShouldReturnUpdatedCarer()
    {
        // arrange
        var c = svc.AddCarer(new Carer
        {
            Firstname = "Daffy",
            Surname = "Duck",
            NationalInsuranceNo = " BR4567123",
            DOB = new DateTime(1964, 09, 24),
            EmailAddress = "Daffy@mail.com",
            Street = " 32 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "07778899007",
            HomeNumber = "028304321",
            Qualifications = "BTEC Level II Social Healthcare"

            // ....
        });


        // act
        var updated = svc.UpdateCarer(new Carer
        {
            Id = c.Id,
            Firstname = c.Firstname,
            Surname = "Changed",
            NationalInsuranceNo = c.NationalInsuranceNo,
            DOB = c.DOB,
            EmailAddress = c.EmailAddress,
            Street = c.Street,
            Town = c.Town,
            County = c.County,
            Postcode = c.Postcode,
            MobileNumber = c.MobileNumber,
            HomeNumber = c.HomeNumber,
            Qualifications = "BTEC Level III Social Healthcare"

            // ....
        });


        // assert
        Assert.NotNull(updated);
        Assert.Equal("Changed", updated.Surname);
        Assert.Equal("BTEC Level III Social Healthcare", updated.Qualifications);
    }
    [Fact]
    public void DeleteCarer_WhenNotExist_ShouldReturnFalse()
    {
        // arrange     

        // act
        var success = svc.DeleteCarer(1);

        // assert
        Assert.False(success);
    }

    [Fact]
    public void DeleteCarer_WhenExists_ShouldReturnTrue()
    {
        // arrange
        var dummy = svc.AddCarer(new Carer
        {
            Firstname = "Minnie",
            Surname = "Mouse",
            // ....
        });

        // act
        var success = svc.DeleteCarer(dummy.Id);

        // assert
        Assert.True(success);
    }

    //======================CareEvent Management Tests================================== 
    [Fact]
    public void AddPatientCareEvent_WhenValid_ShouldReturnCareEvent()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCarer(Factory.MakeCarer());

        // act
        var pce = svc.AddPatientCareEvent(p.Id, c.Id, "CarePlan",
                                            "Notes",
                                            new DateTime(2023, 3, 2, 13, 5, 11, 123));

        Assert.NotNull(p);
        Assert.NotNull(c);
        Assert.NotNull(pce);
        Assert.Equal("CarePlan", pce.CarePlan);
        Assert.Equal("Notes", pce.Notes);

    }

    [Fact]
    public void AddPatientCareEvent_WhenInPast_ShouldNotAddCareEvent()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCarer(Factory.MakeCarer());
        var pce1 = svc.AddPatientCareEvent(p.Id, c.Id, "CarePlan",
                                            "Notes",
                                            new DateTime(2023, 3, 2, 13, 5, 11, 123));

        // act - create care event in past (before last care event)
        var pce2 = svc.AddPatientCareEvent(p.Id, c.Id, "CarePlan",
                                            "Notes",
                                            new DateTime(2023, 3, 1, 13, 5, 11, 123));

        Assert.NotNull(p);
        Assert.NotNull(c);
        Assert.NotNull(pce1);

        Assert.Null(pce2);
    }

    [Fact]
    public void GetPatientCareEvents_WhenExists_ShouldReturnCareEvent()
    {
        // arrange
        var carer = svc.AddCarer(new Carer
        {
            Title = " Mr ",
            Firstname = "Minnie",
            Surname = "Mouse",
            NationalInsuranceNo = "CD987654321",
            DOB = new DateTime(1983, 03, 04),
            EmailAddress = "Minnie@mail.com",
            Street = " 30 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567898",
            HomeNumber = "028302515",
            Qualifications = "BTEC Level II Social Healthcare"

            // ....
        });
        var p = svc.AddPatient(new Patient
        {
            Firstname = "John",
            Surname = "White",
            NationalInsuranceNo = " BR234567",
            DOB = new DateTime(1947, 09, 24),
            Email = "john@mail.com",
            Street = " 28 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567891",
            HomeNumber = "028301234",
            GP = " Dr R Campbell",
            SocialWorker = "Cathy Burke ",
            CarePlan = "Get dressed and washed",
            PhotoUrl =  "/images/carer.jpg"
            // ....
        });

        var pce = new PatientCareEvent
        {
            CarePlan = "Make lunch",
            Notes = "Very quiet today, no appetite",
            CarerId = carer.Id,
            PatientId = p.Id,
            DateTimeOfEvent = new DateTime(2022, 3, 9, 16, 5, 7, 123),
            // ....
        };
        
        var gpce = svc.GetPatientCareEventById(pce.Id);
        // assert
        Assert.NotNull(carer);
        Assert.NotNull(p);
        Assert.NotNull(pce);
        Assert.Null(gpce);

    }


    [Fact]
    public void TestDeletePatientCareEvent__ShouldReturntrue()
    {
        //Arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCarer(Factory.MakeCarer());

        var pce = svc.AddPatientCareEvent(p.Id, c.Id, "Get patient up, washed and dressed",
                                            "Patient not responding this morning",
                                            new DateTime(2023, 3, 2, 13, 5, 11, 123));

        // act
        var deleted = svc.DeletePatientCareEvent(pce.Id);

        // assert
        Assert.True(deleted);
    }


    [Fact]
    public void TestUpdatePatientCareEvent_WhenAdded_ShouldReturntrue()
    {
        // arrange
        var ap = svc.AddPatient(new Patient
        {
            Title = " Mr ",
            Firstname = "Mary",
            Surname = "Brown",
            NationalInsuranceNo = "ZY1098765432B",
            DOB = new DateTime(1941, 03, 04),
            Email = "Mary@mail.com",
            Street = " 45 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "07892891702",
            HomeNumber = "028302515",
            GP = " Dr D Campbell",
            SocialWorker = "John Burke ",
            CarePlan = "Get lunch, clear dishes to dishwasher"
            // ....
        });
        var carer = svc.AddCarer(new Carer
        {
            Title = " Mr ",
            Firstname = "Donald",
            Surname = "Duck",
            NationalInsuranceNo = "CD123456",
            DOB = new DateTime(1968, 03, 04),
            EmailAddress = "Donald@mail.com",
            Street = " 28 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567898",
            HomeNumber = "028302515",
            Qualifications = "BTEC Level III Social Healthcare"

            // ....
        });
        var pce = svc.AddPatientCareEvent(ap.Id, carer.Id, ap.CarePlan, "Notes", DateTime.Now);

        // act -- what is purpose of ap.Id parameter
        pce.Notes = pce.Notes + " Updated";
        var updatedpce = svc.UpdatePatientCareEvent(pce);

        Assert.NotNull(ap);
        Assert.NotNull(carer);
        Assert.NotNull(updatedpce);
        Assert.Equal(ap.Id, ap.Id);
        Assert.Equal(carer.Id, carer.Id);
        Assert.Equal("Notes Updated", updatedpce.Notes);

    }

    //  =====================Test Patient Condition Management================================== 

    [Fact]
    public void AddConditionToPatient_WhenInPast_ShouldNotAddPatientCondition()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCondition(Factory.MakeConditions());

        // act
        var pc = svc.AddPatientCondition(p.Id, c.Id, "PatientNote", new DateTime(2023, 3, 2, 13, 5, 11, 123));
        var pc2 = svc.AddPatientCondition(p.Id, c.Id, "PatientNote", new DateTime(2023, 3, 1, 13, 5, 11, 123));
        // assert
        Assert.NotNull(p);
        Assert.NotNull(c);
        Assert.NotNull(pc);
        Assert.Equal("PatientNote", pc.Note);
        Assert.Null(pc2);

    }
    [Fact]
    public void AddPatientCondition_WhenValid_ShouldReturnPatientCondition()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCondition(Factory.MakeConditions());

        // act
        var pc = svc.AddPatientCondition(p.Id, c.Id, "PatientCondition and notes", new DateTime(2023, 3, 2, 13, 5, 11, 123));

        Assert.NotNull(p);
        Assert.NotNull(c);
        Assert.NotNull(pc);
        Assert.Equal("PatientCondition and notes", pc.Note);

    }

    [Fact]
    public void GetPatientCondition_WhenExists_ShouldReturnPatientConditions()
    {
        // arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCondition(Factory.MakeConditions());
        // act

        var pc = svc.AddPatientCondition(p.Id, c.Id, "PatientCondition and notes", new DateTime(2023, 3, 2, 13, 5, 11, 123));

        var gpc = svc.GetPatientConditionById(pc.Id);
        // assert
        Assert.NotNull(p);
        Assert.NotNull(c);
        Assert.NotNull(pc);
        Assert.NotNull(gpc);
        Assert.Equal("Arthritis", c.Name );
        Assert.Equal( "Arthritis is a condition that causes pain and inflammation in a joint", c.Description );

    }


    [Fact]
    public void TestDeletePatientCondition__ShouldReturntrue()
    {
        //Arrange
        var p = svc.AddPatient(Factory.MakePatient());
        var c = svc.AddCondition(Factory.MakeConditions());

        var pc = svc.AddPatientCondition(p.Id, c.Id, "Condition note",  new DateTime(2023, 3, 2, 13, 5, 11, 123));

        // act
        var deleted = svc.DeleteCondition(pc.Id);

        // assert
        Assert.True(deleted);
    }

    [Fact]
    public void TestUpdatePatientCondition_WhenAdded_ShouldReturnTrue()
    {
        //Arrange
        var ap = svc.AddPatient(Factory.MakePatient());
        var ac = svc.AddCondition(Factory.MakeConditions());
        var pc = svc.AddPatientCondition(ap.Id, ac.Id, "Note Condition",  new DateTime(2023, 3, 2, 13, 5, 11, 123));

        // act -- what is purpose of ap.Id parameter
        pc.Note = pc.Note + " Updated";
        var updatedpc = svc.UpdatePatientCondition(pc);

        Assert.NotNull(ap);
        Assert.NotNull(ac);
        Assert.NotNull(updatedpc);
        Assert.Equal(ap.Id, ap.Id);
        Assert.Equal(ac.Id, ac.Id);

        Assert.Equal("Note Condition Updated", updatedpc.Note);

    }
    //======================Family Management Testss=================================
     //======================Patient Family Management Tests==================================

    [Fact]
    public void AddFamilyMember_WhenValid_ShouldReturnFamilyMember()
    {
        // arrange
        var fm = svc.AddFamily(Factory.AddFamily());

        // assert
        Assert.NotNull(fm);
        Assert.Equal("Minnie", fm.Firstname);
        Assert.Equal("Mouse", fm.Surname);
        Assert.Equal("07778899032", fm.MobileNumber);
        Assert.Equal("Minnie@gmail.com", fm.EmailAddress);
    }
    [Fact]
    public void GetFamily_WhenExists_ShouldReturnFamily()
    {
        // arrange
        var fm = svc.AddFamily(Factory.AddFamily());


        // act
        var gfm = svc.GetFamilyMemberById(fm.Id);

        // assert -- TODO Check for other properties

        Assert.NotNull(gfm);
        Assert.Equal(fm.Firstname, fm.Firstname);
        Assert.Equal(fm.Surname, fm.Surname);
        Assert.Equal(fm.EmailAddress, fm.EmailAddress);
        Assert.Equal(fm.MobileNumber, fm.MobileNumber);

    }
    [Fact]
    public void UpdateFamily_WhenExistsAndIsValid_ShouldReturnUpdatedFamily()
    {
        // arrange
        var fm = svc.AddFamily(Factory.AddFamily());

        // act == TODO - need to check for all properties except Id
        var updatedfm = svc.UpdateFamily(new FamilyMember
        {
            Id = fm.Id,
            Firstname = fm.Firstname,
            Surname = "Changed Surname",
            EmailAddress = fm.EmailAddress,
            MobileNumber = "0000111122223333",
            // ....
        });
        }
    //     [Fact]
    // // public void TestRemovePatientFamilyMember__ShouldReturntrue()
    // // {
    // //     //Arrange
    // //     var p = svc.AddPatient(Factory.MakePatient());
    // //     var fm = svc.AddFamily(Factory.AddFamily());
    // //     var pf = svc.AddPatientFamily( p.Id,fm.Id,false);

    // //     // act
    // //     var rpfm = svc.RemovePatientFamily(pf.Id);

    // //     // assert
    // //     Assert.True(rpfm);
    // //     Assert.NotNull(p);
    // //     Assert.NotNull(fm);
    // //     Assert.NotNull(pf);       
    // // }

} 


static class Factory
{

    public static Patient MakePatient()
    {
        return new Patient
        {
            Title = " Mr ",
            Firstname = "Mary",
            Surname = "Brown",
            NationalInsuranceNo = "ZY1098765432B",
            DOB = new DateTime(1941, 03, 04),
            Email = "Mary@mail.com",
            Street = " 45 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "07892891702",
            HomeNumber = "028302515",
            GP = " Dr D Campbell",
            SocialWorker = "John Burke ",
            CarePlan = "Get lunch, clear dishes to dishwasher"
            // ....
        };
    }

    public static Carer MakeCarer()
    {
        return new Carer
        {
            Title = " Mr ",
            Firstname = "Donald",
            Surname = "Duck",
            NationalInsuranceNo = "CD123456",
            DOB = new DateTime(1968, 03, 04),
            EmailAddress = "Donald@mail.com",
            Street = " 28 Warren Hill ",
            Town = "Newry",
            County = " Down",
            Postcode = " BT34 2PH",
            MobileNumber = "01234567898",
            HomeNumber = "028302515",
            Qualifications = "BTEC Level III Social Healthcare"
            // ....
        };
    }

    public static Condition MakeConditions()
    {
        return new Condition {
        Name = "Arthritis", 
        Description = "Arthritis is a condition that causes pain and inflammation in a joint"

        };
    }
    public static FamilyMember AddFamily()
    {
        return new FamilyMember
        {   
            Firstname = "Minnie",
            Surname = "Mouse",
            MobileNumber = "07778899032",
            EmailAddress = "Minnie@gmail.com",

            // ....
        };
    }
         
    }


