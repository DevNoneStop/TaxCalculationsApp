using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaxCal.API.Models
{
   
        [Table("Employee", Schema = "dbo")]
        public class Employee
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int EmployeeId { get; set; }
                   
            public string? Name { get; set; }
                   
            public double Income { get; set; }
                    
            public string? PostalCode { get; set; }
                   
            public double TaxCalculated { get; set; }
                    
            public DateTime? CreatedDate { get; set; }
        }
   
}
