using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data.Models;

public class Condition
{
    public int Id { get; set; }
    public string Name { get; set; }   

    [Required][StringLength(500, MinimumLength = 1)]
    public string Description { get; set; }


}

