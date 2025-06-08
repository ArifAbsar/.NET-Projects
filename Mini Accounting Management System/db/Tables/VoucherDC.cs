using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Accounting_Management_System.db.Tables
{
    
    public class VoucherDC
    {
        [Key]
        public int LineID { get; set; }

        [ForeignKey(nameof(Voucher))]
        public int VoucherID { get; set; }
        public Voucher Voucher { get; set; } = default!;

        [ForeignKey("SubAccount")]
        public int SubAccountID { get; set; }
        public SubAccount SubAccount { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }
    }
}
