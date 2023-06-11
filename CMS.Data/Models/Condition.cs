using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Models;

public class Condition
{
    public int Id { get; set; }
    public string Name { get; set; }   

    [Required][StringLength(500, MinimumLength = 1)]
    public string Description { get; set; }


    public List<Condition> Conditions { get; set;} = new List<Condition>();
    public List<PatientCondition> PatientCondition { get; set;} = new List<PatientCondition>();
    public List<PatientCareEvent> CareEvents { get; set; }
    public List<PatientFamily> PatientFamilies { get; set;}

}

