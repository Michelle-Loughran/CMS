using Microsoft.EntityFrameworkCore;
using CMS.Data.Repositories;
using CMS.Data.Models;

namespace CMS.Data.Services;

public class PatientServiceDb : IPatientService
{
    private readonly PatientDbContext db;


    public PatientServiceDb()
    {
        db = new PatientDbContext();
    }

    public void Initialise()
    {
        db.Initialise();
    }

    //==========================Patient Functions===========================================

    // Return a list of Patients 
    public IList<Patient> GetAllPatients(string order = null)
    {
        return db.Patients.ToList();
    }

    //View specific patient by Id displaying information
    public Patient GetPatientById(int id)
    {
        return db.Patients
                    .Include(p => p.Conditions)
                    // .ThenInclude(pc => pc.Conditions)
                    // .ThenInclude(fm => fm.FamilyMember)
                    .Include(p => p.CareEvents)
                    .ThenInclude(ce => ce.Carer)
                    .FirstOrDefault(p => p.Id == id);
    }

    public IList<Patient> SearchPatients(string query)
    {
        // TODO - query to search patient name, national ins etc containing query
        return new List<Patient>();
    }

    //Create a new patient and store to the Database
    public Patient AddPatient(Patient p)
    {
        //check patient being passed does not exist
        var exists = GetPatientById(p.Id);
        
        if (exists != null)
        {
            return null; // Patient cannot be added as they already exist
        }

        // update the information for the patient and save
        var patient = new Patient
        {
            Title = p.Title,
            Firstname = p.Firstname,
            Surname = p.Surname,
            NationalInsuranceNo = p.NationalInsuranceNo,
            DOB = p.DOB,
            Street = p.Street,
            Town = p.Town,
            County = p.County,
            Postcode = p.Postcode,
            HomeNumber = p.HomeNumber,
            MobileNumber = p.MobileNumber,
            Email = p.Email,
            GP = p.GP,
            SocialWorker = p.SocialWorker,
            CarePlan = p.CarePlan,
            PhotoUrl = p.PhotoUrl,
            CareEvents = p.CareEvents,
            Conditions = p.Conditions,

            // check for missing attributes
        };

        //add patient to database
        db.Patients.Add(patient);
        db.SaveChanges();
        return patient;// return added patient to database
    }

    //Edit an existing patient (selected by name and dob) and update the database
    public Patient UpdatePatient(Patient updated)
    {
        // verify the patient exists
        var patient = GetPatientById(updated.Id);
        if (patient == null)
        {
            return null;
        }

        // check for another patient with the NationalInsuranceNo
        var found = db.Patients
                      .FirstOrDefault(p => p.NationalInsuranceNo == updated.NationalInsuranceNo &&
                                           p.Id != updated.Id);
        if (found != null)
        {
            return null;
        }

        // update the information for the patient and save
        patient.Title = updated.Title;
        patient.Firstname = updated.Firstname;
        patient.Surname = updated.Surname;
        patient.NationalInsuranceNo = updated.NationalInsuranceNo;
        patient.DOB = updated.DOB;
        patient.Street = updated.Street;
        patient.Town = updated.Town;
        patient.County = updated.County;
        patient.Postcode = updated.Postcode;
        patient.HomeNumber = updated.HomeNumber;
        patient.MobileNumber = updated.MobileNumber;
        patient.Email = updated.Email;
        patient.GP = updated.GP;
        patient.SocialWorker = updated.SocialWorker;
        patient.CarePlan = updated.CarePlan;
        patient.CareEvents = updated.CareEvents;
        // check for missing attributes

        db.SaveChanges();
        return patient;
    }

    // Delete the patient identified by Id returning true if deleted and false if not found
    public bool DeletePatient(int id)
    {
        var p = GetPatientById(id);
        if (p == null)
        {
            return false;
        }
        db.Patients.Remove(p);
        db.SaveChanges();
        return true;
    }

    //==========================Carer Functions===========================================
    // retrieve list of Carers with their main details
    public IList<Carer> GetAllCarers(string order = null)
    {
        return db.Carers
                .ToList();
    }

    // retrieve specific Carer with their main details
       public Carer GetCarerById(int id)
    {
        return db.Carers
                    .Include(c => c.PatientCareEvents) // patient care events carried out by this carer
                    .FirstOrDefault(c => c.Id == id);
    }

    // retrieve specific Carer with their email
    public Carer GetCarerByEmail(string email)
    {
        return db.Carers.FirstOrDefault(c => c.EmailAddress == c.EmailAddress);

    }

    public Carer AddCarer(Carer c)
    {
        //check carer being passed does not exist
        var exists = GetCarerById(c.Id);
        if (exists != null)
        {
            return null; // the Carer already exists
        }

        // create the carer and save
        var carer = new Carer
        {
            Firstname = c.Firstname,
            Surname = c.Surname,
            DOB = c.DOB,
            NationalInsuranceNo = c.NationalInsuranceNo,
            DBSCheck = c.DBSCheck,
            EmailAddress = c.EmailAddress,
            Street = c.Street,
            Town = c.Town,
            County = c.County,
            Postcode = c.Postcode,
            MobileNumber = c.MobileNumber,
            HomeNumber = c.HomeNumber,
            Qualifications = c.Qualifications,
            PhotoUrl = c.PhotoUrl
        };

        //add Carer to database
        db.Carers.Add(carer);
        db.SaveChanges();
        return carer;
    }

    // Delete the carer identified by Id returning true if deleted and false if not found
    public bool DeleteCarer(int carerId)
    {
        var c = GetCarerById(carerId);
        if (c == null)
        {
            return false;
        }
        db.Carers.Remove(c);
        db.SaveChanges();
        return true;
    }

    public Carer UpdateCarer(Carer updated)
    {
        // verify the carer exists
        var carer = GetCarerById(updated.Id);
        if (carer == null)
        {
            return null;
        }

        // check for another patient with the NationalInsuranceNo
        var found = db.Carers
        .FirstOrDefault(c => c.NationalInsuranceNo == updated.NationalInsuranceNo &&
                                           c.Id != updated.Id);
        if (found != null)
        {
            return null;
        }

        // update the information for the carer and save         
        carer.Firstname = updated.Firstname;
        carer.Surname = updated.Surname;
        carer.DOB = updated.DOB;
        carer.NationalInsuranceNo = updated.NationalInsuranceNo;
        carer.DBSCheck = updated.DBSCheck;
        carer.EmailAddress = updated.EmailAddress;
        carer.Street = updated.Street;
        carer.Town = updated.Town;
        carer.County = updated.County;
        carer.Postcode = updated.Postcode;
        carer.MobileNumber = updated.MobileNumber;
        carer.HomeNumber = updated.HomeNumber;
        carer.Qualifications = updated.Qualifications;

        db.SaveChanges();
        return carer;
    }

    //  //======================CareEvent Management==================================
     
    public IList<PatientCareEvent> GetAllPatientCareEvents(string order = null)
    {
        return db.PatientCareEvents
                 .Include(ce => ce.Patient)
                 .Include(ce => ce.Carer)
                 .ToList();
    }

    public PatientCareEvent GetPatientCareEventById(int id)
    {
        return db.PatientCareEvents
                 .Include(ce => ce.Patient)
                 .Include(ce => ce.Carer)
                 .FirstOrDefault(pce => pce.Id == id);
    }

    public PatientCareEvent AddPatientCareEvent(int patientId, int carerId, string careplan, string notes, DateTime on)
    {
        // check that on is > last care event on
        var last = db.PatientCareEvents.Where(ce => ce.PatientId == patientId)
                     .OrderByDescending(ce => ce.DateTimeOfEvent).FirstOrDefault();
        if (last != null && last.DateTimeOfEvent >= on)
        {
            return null;
        }

        //check patient being passed exists
        var patient = GetPatientById(patientId);
        var carer = GetCarerById(carerId);

        if (patient == null || carer == null)
        {
            return null; // Patient or Carer does not exist
        }

        // update the information for the patientcareevent and save
        var pc = new PatientCareEvent
        {
            PatientId = patientId,
            CarerId = carerId,
            CarePlan = careplan,
            Notes = notes,
            DateTimeOfEvent = on
        };

        //add patient to database
        db.PatientCareEvents.Add(pc);
        db.SaveChanges();
        return pc;
    }


    public bool DeletePatientCareEvent(int careEventId)
    {
        var pce = db.PatientCareEvents.FirstOrDefault(e => e.Id == careEventId);
        if (pce == null)
        {
            return false;
        }
        db.PatientCareEvents.Remove(pce);
        db.SaveChanges();
        return true;
    }


    public PatientCareEvent UpdatePatientCareEvent(PatientCareEvent updated)
    {
        var patientCareEvent = GetPatientCareEventById(updated.Id);
        if (patientCareEvent == null)
        {
            return null;
        }
        // update patient care event      
        patientCareEvent.PatientId = updated.PatientId;
        patientCareEvent.CarerId = updated.CarerId;
        patientCareEvent.CarePlan = updated.CarePlan;
        patientCareEvent.Notes = updated.Notes;
        patientCareEvent.DateTimeOfEvent = updated.DateTimeOfEvent;
        db.SaveChanges();
        return patientCareEvent;
    }

    //  ====================== Condition Management==================================
        public IList<Condition> GetAllConditions(string order=null)
    {
        return db.Conditions.ToList();

    }

    // Condition GetConditionById(int id);
    public Condition GetConditionById(int id)
    {
        return db.Conditions.FirstOrDefault(c => c.Id == id);
         
        //  .Include(d => d.Description)
        // .FirstOrDefault(co => co.Id == id);

    }
    public Condition AddCondition(Condition con)
    {
        var exists = GetConditionById(con.Id);

        if (exists != null)
        {
            return null; // Condition does not exist
        }

        var condition = new Condition
        {
            Name = con.Name,
            Description = con.Description

        };
        //add condition to database
        db.Conditions.Add(condition);
        db.SaveChanges();
        return condition;
    }



    //Condition DeleteCondition(int id);
    public bool DeleteCondition(int id)
    {
        var dc = GetConditionById(id);
        if (dc == null)
        {
            return false;
        }
        db.Conditions.Remove(dc);
        db.SaveChanges();
        return true;
    }

    // Condition UpdateCondition(int id, Condition updated);
    public Condition UpdateCondition(Condition updated)
    {
        var condition = GetConditionById(updated.Id);
        if (condition == null)
        {
            return null;
        }

        condition.Name = updated.Name;
        condition.Description = updated.Description;
        condition.Id = updated.Id;

        db.SaveChanges();
        return condition;
    }

    //  ======================Patient Condition Management==================================

    public IList <PatientCondition> GetAllPatientConditions(string order = null)
    {
                return db.PatientConditions
                 .Include(ce => ce.Patient)
                 .Include(ce => ce.Condition)
                 .ToList();
    }
    public PatientCondition GetPatientConditionById(int id)
    {
        return db.PatientConditions
                .Include(ce => ce.Patient)
                .Include(ce => ce.Condition)
                .FirstOrDefault(pc => pc.Id ==id);

    }
    public PatientCondition AddPatientCondition(int patientId, int conditionId, string note, DateTime on)
    {
        var pc = db.PatientConditions.Where(ce => ce.PatientId == patientId)
         .OrderByDescending(ce => ce.DateTimeConditionAdded).FirstOrDefault();

        if (pc != null && pc.DateTimeConditionAdded >= on)
        {
            return null;
        }

        //check patient being passed exists
        var patient = GetPatientById(patientId);
        var condition = GetConditionById(conditionId);
        if (pc != null)
        {
            return null;
        }

        if (patient == null || condition == null)
        {
            return null; // Patient or Condition does not exist
        }
        var patientCondition = new PatientCondition
        {
            PatientId = patientId,
            ConditionId = conditionId,
            Note = note, 
            DateTimeConditionAdded = on
        };


        db.PatientConditions.Add(patientCondition);
        db.SaveChanges();
        return patientCondition;
    }

    public bool RemovePatientCondition(int conditionId)
    {
        var rpc =db.PatientConditions.FirstOrDefault(e => e.Id == conditionId);
        if (rpc == null)
        {
            return false;
        }
    
        db.PatientConditions.Remove(rpc);
        db.SaveChanges();
        return true;
    }

    public PatientCondition UpdatePatientCondition(PatientCondition updated)
    {
        var pc = GetPatientConditionById(updated.Id);
        if (pc == null)
        {
            return null;
        }
        // update note
        pc.Id = updated.Id;
        pc.Note = updated.Note;
        db.PatientConditions.Update(pc);
        db.SaveChanges();
        return pc;
    }


    //  ======================Family Management==================================

    // missing attributes
        public IList<FamilyMember> GetAllFamilies(string order = null)
    {
        return db.FamilyMembers.ToList();
    }
    public FamilyMember AddFamily(FamilyMember added)
    {
        var exists = db.FamilyMembers.FirstOrDefault(f => f.EmailAddress ==  added.EmailAddress);
        if (exists != null)
        {
            return null;
        };

        var f = new FamilyMember
        {
            Firstname = added.Firstname,
            Surname = added.Surname,
            EmailAddress = added.EmailAddress,
            MobileNumber = added.MobileNumber
        };

        db.FamilyMembers.Add(f);
        db.SaveChanges();
        return f; // return newly added student
    }

    public bool DeleteFamily(int id)
    {
        var f = GetFamilyMemberById(id);
        if (f == null)
        {
            return false;
        }
        db.FamilyMembers.Remove(f);
        db.SaveChanges();
        return true;
    }

    public FamilyMember UpdateFamily(FamilyMember updated)
    {
        // verify the student exists
        var family = GetFamilyMemberById(updated.Id);
        if (family == null)
        {
            return null;
        }
        // update the details of the student retrieved and save
        family.Firstname = updated.Firstname;
        family.Surname = updated.Surname;
        family.EmailAddress = updated.EmailAddress;
        family.MobileNumber = updated.MobileNumber;

        db.SaveChanges();
        return family;
    }

    public FamilyMember GetFamilyMemberById(int id)
    {
        return db.FamilyMembers
                .FirstOrDefault(f => f.Id == id);
    }

    //======================Patient Family Management==================================
    public IList<PatientFamily> GetPatientFamily(string order = null)
    {
        return db.PatientFamilies
            .Include(pf => pf.Patient)
            .Include(pf => pf.FamilyMember)
            .ToList();
    }
    public PatientFamily GetPatientFamilyMemberById(int id)
    {
        return db.PatientFamilies
            .Include(pf => pf.Patient)
            .Include(pf => pf.FamilyMember)
            .FirstOrDefault(pf => pf.Id == id);
    }
    public PatientFamily AddPatientFamily(int patientId, int familymemberId, bool primary = false)
    {
        var pf = db.PatientFamilies.Where(ce => ce.PatientId == patientId);
   
        if (pf != null)
        {
            return null;
        }
            var patient = GetPatientById(patientId);
            var familymember = GetPatientFamilyMemberById(familymemberId);

        if (pf != null)
        {
            return null;
        }

                if (patient == null || familymember == null)
        {
            return null; // Patient or Condition does not exist
        }
             var fp = new PatientFamily
        {
            PatientId = patientId,
            FamilyMemberId = familymemberId,
            Primary = primary,
        };
        db.PatientFamilies.Add(fp);
        db.SaveChanges();
        return fp;
    }
    public PatientFamily UpdatePatientFamily(PatientFamily updated)
     {
        var pf = GetPatientFamilyMemberById(updated.Id);
        if (pf == null)
        {
            return null;
        }
        // update note
        pf.Id = updated.Id;
        pf.FamilyMember = updated.FamilyMember;
        db.PatientFamilies.Update(pf);
        db.SaveChanges();
        return pf;
    }
    public bool RemovePatientFamily(int familymemberId)
    {
        var rpf = db.PatientFamilies.FirstOrDefault(e => e.Id == familymemberId);
        if (rpf == null)
        {
            return false;
        }
        db.PatientFamilies.Remove(rpf);
        db.SaveChanges();
        return true;
    }

}

