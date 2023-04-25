namespace CMS.Data.Models;

public class FamilyMember
{
    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
   
    public string MobileNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;

    // ....

    // relationships

    // a family member has a login account
    // public int UserId { get; set; }
    // public User User { get; set; }

    // a family member can belong to 1 or more patient families (normally 1)
    public List<PatientFamily> PatientFamily { get; set;} = new List<PatientFamily>();
}
