using CMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CMS.Data.Repositories;
public class PatientDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Carer> Carers { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<PatientCondition> PatientConditions { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }
    public DbSet<PatientFamily> PatientFamily { get; set; }

    public DbSet<PatientCareEvent> PatientCareEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Filename= data.db")
               //.LogTo(Console.WriteLine, LogLevel.Information)
               ;

    }

    public void Initialise()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

}
