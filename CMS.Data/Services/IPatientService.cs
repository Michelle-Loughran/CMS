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
        Carer GetCarerById(int id);
        Carer GetCarerByEmail(string email);
        Carer AddCarer(Carer c );
        bool DeleteCarer(int id);
        Carer UpdateCarer(Carer updated);

        //======================CareEvent Management==================================
        IList<PatientCareEvent> GetAllPatientCareEvents(string order=null);
        PatientCareEvent GetPatientCareEventById(int id);
        PatientCareEvent AddPatientCareEvent(DateTime dt, string careplan, string issues, int calls, TimeOnly call1,TimeOnly call2,TimeOnly call3,TimeOnly call4,TimeOnly call5,int patientId, int carerId);
        bool DeletePatientCareEvent(int careEventId);
        PatientCareEvent UpdatePatientCareEvent(PatientCareEvent updated);

        //=============================Condition Management===================================
        IList<Condition> GetAllConditions(string order=null);
        Condition AddCondition(Condition condition);
        bool DeleteCondition(int id);
        Condition UpdateCondition(Condition updated);
        Condition GetConditionById(int id);
    

        //======================Patient Condition Management==================================
        IList<PatientCondition> GetAllPatientConditions(string order=null);
        PatientCondition GetPatientConditionById(int id);
        PatientCondition AddPatientCondition(int patientId, int conditionId, string note, DateTime on);
        bool RemovePatientCondition(int conditionId);
        PatientCondition UpdatePatientCondition(PatientCondition updated);

        //======================Family Management==================================
        IList<FamilyMember> GetAllFamilies(string order = null);
        FamilyMember AddFamily(FamilyMember fm);
        bool DeleteFamily(int id);
        FamilyMember UpdateFamily(FamilyMember updated);
        FamilyMember GetFamilyMemberById(int id);


        //======================Patient Family Management==================================
        IList<PatientFamily> GetPatientFamily(string order = null);
        PatientFamily GetPatientFamilyMemberById(int id);
        PatientFamily AddPatientFamily(int patientId, int familymemberId, bool primary = false);
        PatientFamily UpdatePatientFamily(PatientFamily updated);
        bool RemovePatientFamily(int id);
    }

}
