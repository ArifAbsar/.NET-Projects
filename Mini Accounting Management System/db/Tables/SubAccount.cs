using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Accounting_Management_System.db.Tables
{
    public class SubAccount
    {
        [Key]
        public int S_ID { get; set; }
        [Required]
        public int Type_A_ID { get; set; }
        public required string Sub_Acc { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Balance { get; set; } = 0;
        [ForeignKey(nameof(Type_A_ID))]
        public AccountType AccountType { get; set; } = default!;
        public ICollection<Journal_Voucher> JournalVouchers { get; set; } = new List<Journal_Voucher>();
        public ICollection<Payment_Voucher> PaymentVouchers { get; set; } = new List<Payment_Voucher>();
        public ICollection<Reciept_Voucher> RecieptVouchers { get; set; } = new List<Reciept_Voucher>();

    }
}
