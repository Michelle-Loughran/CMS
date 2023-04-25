using CMS.Data.Models;

namespace CMS.Data.Services
{
    public interface IPatientService
    {
        void Initialise();

        //======================Patient Management==================================
        IList<Patient> GetAllPatients(string order = null);
        Patient GetPatientById(int id);
        IList<Patient> SearchPatients(string query);
        Patient AddPatient(Patient p);
        bool DeletePatient(int id);
        Patient UpdatePatient(Patient updated);
      
        //======================Carer Management==================================
        IList<Carer> GetAllCarers(string order=null);
        Carer GetCarer(int id);
        Carer GetCarerByEmail(string email);
        Carer AddCarer(Carer c );
        bool DeleteCarer(int id);
        Carer UpdateCarer(Carer updated);

        //======================CareEvent Management==================================
        IList<PatientCareEvent> GetAllPatientCareEvents(string order=null);
        PatientCareEvent GetPatientCareEventById(int id);
        PatientCareEvent AddPatientCareEvent(int patientId, int carerId, string careplan, string notes, DateTime on);
        bool DeletePatientCareEvent(int careEventId);
        PatientCareEvent UpdatePatientCareEvent(PatientCareEvent updated);

        //=============================Condition Management===================================
        Condition AddCondition(string name, string description);
        bool DeleteCondition(int id);
        Condition UpdateCondition(Condition updated);
        Condition GetCondition(int id);
        IList <Condition> GetAllConditions();

        //======================Patient Condition Management==================================
        PatientCondition GetPatientCondition(int patientId, int conditionId);
        PatientCondition AddConditionToPatient(int patientId, int conditionId, string note);
        bool RemoveConditionFromPatient(int patientId, int conditionId);
        PatientCondition UpdatePatientCondition(PatientCondition updated);
        IList<PatientCondition> GetAllPatientConditions(int patientId);

        //======================Family Management==================================
        FamilyMember AddFamily(FamilyMember fm);
        bool DeleteFamily(int id);
        FamilyMember UpdateFamily(FamilyMember updated);
        FamilyMember GetFamilyById(int id);

        //======================Patient Family Management==================================
        IList<PatientFamily> GetPatientFamily();
        PatientFamily GetPatientFamilyById(int patientId, int familymemberId);
        PatientFamily AddPatientFamily(int patientId, int familymemberId, bool primary = false);
        // bool RemovePatientFamily(int patientId, int familymemberI);
        // bool MakeFamilyPrimaryContact(int id);
      
    }

}