using System.ComponentModel.DataAnnotations;

namespace Mini_Accounting_Management_System.Helper
{
    public class PLINE
    {
        [Required]
        public int SubAccountID { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Debit { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Credit { get; set; }
    }
}
