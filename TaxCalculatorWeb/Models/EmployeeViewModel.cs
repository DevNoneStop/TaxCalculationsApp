using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculatorWeb.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

       
        [DisplayName("Employee name")]
        public string? Name { get; set; }
  
        [DisplayName("Annual income")]
        public double Income { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }

        [DisplayName("Tax Calculated")]
        public double TaxCalculated { get; set; }

        [Column("Created date")]
        public DateTime? CreatedDate { get; set; }
    }
}
