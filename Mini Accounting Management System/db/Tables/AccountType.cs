using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mini_Accounting_Management_System.db.Tables
{
    public class AccountType
    {
        [Key]
        public int A_ID { get; set; }
        public required string Acc_Type { get; set; }
        [Precision(18, 2)]
        public decimal TotalBalance { get; set; } = 0;

        public ICollection<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();

    }
}
