namespace CMS.Data.Models;

public class Condition
{
    public int Id { get; set; }
    public string Name { get; set; }   
    public string Description { get; set; }
    public List<PatientCondition> PatientCondition { get; set;} = new List<PatientCondition>();
}