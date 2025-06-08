namespace Mini_Accounting_Management_System.DTO
{
    public class Reciept_VDTO
    {
        public int R_ID { get; set; }
        public string ReferenceNo { get; set; } = "";
        public int SubAccountID { get; set; } 
        public DateTime VoucherDate { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
