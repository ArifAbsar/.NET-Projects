using System.ComponentModel.DataAnnotations;

namespace Mini_Accounting_Management_System.db.Tables
{
    public class Account
    {
        [Key]
        public int P_ID { get; set; }
        public required string Acc_Type { get; set; }
        public required string Sub_Acc { get; set; }
        public Decimal Balance { get; set; } = 0;
    }
}
