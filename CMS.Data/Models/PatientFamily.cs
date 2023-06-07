namespace CMS.Data.Models;

public class PatientFamily
{
    public int Id { get; set; }


    // is family member the primary carer
    public bool Primary { get; set; } = false;

    // relationships

    //Foreign keys the patient related to the familymember
    public int PatientId { get; set; }
    public Patient Patient { get; set; }


    //Foreign keys the family member of the patient
    public int FamilyMemberId { get; set; }
    public FamilyMember FamilyMember { get; set; }
}
