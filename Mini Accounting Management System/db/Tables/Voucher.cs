using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Accounting_Management_System.db.Tables
{
    public class Voucher
    {
        [Key]
        public int VoucherID { get; set; }

        [Required]
        [StringLength(1)]
        [Column(TypeName = "char(1)")]
        public string VoucherType { get; set; } = default!;
        // 'J' = Journal, 'P' = Payment, 'R' = Receipt

        [Required]
        public DateTime VoucherDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReferenceNo { get; set; } = default!;

        [Required]
        public DateTime CreatedAt { get; set; }

        // Navigation property for the child lines, if you have a VoucherLines entity
        public ICollection<VoucherDC>? Voucherdc { get; set; }

    }
}
