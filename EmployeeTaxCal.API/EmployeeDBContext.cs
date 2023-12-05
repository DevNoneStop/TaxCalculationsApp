using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EmployeeTaxCal.API.Models;

namespace EmployeeTaxCal.API
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
            try
            {
                //Database creator object to create the DB if it doesn't  exist
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if (dbCreator != null)
                {   // create db if cannot connect
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    //Create Tables if no tables exist
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
