using System.ComponentModel.DataAnnotations;

namespace Mini_Accounting_Management_System.Helper
{
    public class JournalHead
    {
        [Required, StringLength(50)]
        public string ReferenceNo { get; set; } = "";

        [Required, DataType(DataType.Date)]
        public DateTime VoucherDate { get; set; } = DateTime.Today;
    }
}
