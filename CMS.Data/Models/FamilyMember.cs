using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Models;

public class FamilyMember
{
    public int Id { get; set; }
    [Required][StringLength(80, MinimumLength = 1)]
    public string Firstname { get; set; } = string.Empty;
    [Required][StringLength(80, MinimumLength = 1)]
    public string Surname { get; set; } = string.Empty;
    [Required][StringLength(11)]
    public string MobileNumber { get; set; } = string.Empty;
    [Required][StringLength(11)]
    public string EmailAddress { get; set; } = string.Empty;

    // ....

    // relationships

    // a family member has a login account
    // public int UserId { get; set; }
    // public User User { get; set; }

    // a family member can belong to 1 or more patient families (normally 1)
    public List<PatientFamily> PatientFamilies { get; set;} = new List<PatientFamily>();
}
