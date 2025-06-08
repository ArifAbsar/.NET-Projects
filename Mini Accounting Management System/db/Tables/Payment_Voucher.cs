using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mini_Accounting_Management_System.db.Tables
{
    public class Payment_Voucher
    {
        [Key]
        public int Pay_ID { get; set; }
        [Required, MaxLength(50)]
        public string ReferenceNo { get; set; } = null!;

        [Required]
        public int SubAccountID { get; set; }

        [ForeignKey(nameof(SubAccountID))]
        public SubAccount SubAccount { get; set; } = null!;

        [Required]
        public DateTime VoucherDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
