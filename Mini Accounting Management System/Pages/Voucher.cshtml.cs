using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Mini_Accounting_Management_System.DTO;
using System.Data;
using System.Drawing;
using Mini_Accounting_Management_System.Helper;
namespace Mini_Accounting_Management_System.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IConfiguration _config;
        public PrivacyModel(IConfiguration config)
        {
            _config = config;
           
        }

        public List<SubAccountDTO> AllSubAccounts { get; set; }
        public List<Journal_VDTO> JournalVouchers { get; set; } = new();
        public List<Payment_VDTO> PaymentVouchers { get; set; } = new();
        public List<Reciept_VDTO> ReceiptVouchers { get; set; } = new();
        [BindProperty]
        public List<Journal_VDTO> JournalLines { get; set; }
        = new List<Journal_VDTO> { new Journal_VDTO() };

        [BindProperty]
        public List<Payment_VDTO> PaylLines { get; set; }
        = new List<Payment_VDTO> { new Payment_VDTO() };

        [BindProperty]
        public List<Reciept_VDTO> RecieptLines { get; set; }
        = new List<Reciept_VDTO> { new Reciept_VDTO() };

        [BindProperty]
        public JournalHead JournalHeader { get; set; } = new();
        [BindProperty]
        public JLINE JounalLines { get; set; } = new ();
        [BindProperty]
        public PaymentHeader PaymentHeader { get; set; } = new();
        // Fix for CS1579: Ensure that PaymentLines is a collection type that implements IEnumerable.  
        // Update the type of PaymentLines to a collection of PLINE objects.  

        [BindProperty]
        public List<PLINE> PaymentLines { get; set; } = new List<PLINE>();

        [BindProperty]
        public RecieptHeader ReceiptHeader { get; set; } = new();
        //[BindProperty]
        //public List<RLINE> ReceiptLines { get; set; } = new List<RLINE>();
        public void OnGet()
        {
            string connString = _config.GetConnectionString("DefaultConnection");
            AllSubAccounts = AccountHelper.GetSubAccounts(connString);
            JournalVouchers = AccountHelper.GetJournalVouchers(connString);
            PaymentVouchers = AccountHelper.LoadPaymentVouchers(connString);
            ReceiptVouchers = AccountHelper.LoadReceiptVouchers(connString);

        }
        public IActionResult OnPostCreateJournal()
        {
            string connString = _config.GetConnectionString("DefaultConnection");

            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in JournalLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }


            // 2) build the list of tuples manually (no Select)
            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in JournalLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }
            // 2) Call helper
            AccountHelper.InsertJournalVoucher(
                connString,
                JournalHeader.ReferenceNo,
                JournalHeader.VoucherDate,
                JournalLines.Select(l => (l.SubAccountID, l.Debit, l.Credit))
            );

            // 3) back to GET (clears the form)
            return RedirectToPage();
        }
        public IActionResult OnPostAddPaymentLine()
        {
            string connString = _config.GetConnectionString("DefaultConnection");
            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in PaymentLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }


            // 2) build the list of tuples manually (no Select)
            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in PaymentLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }

            AccountHelper.InsertPaymentVoucher(
                connString,
                PaymentHeader.ReferenceNo,
                PaymentHeader.VoucherDate,
                PaymentLines.Select(l => (l.SubAccountID, l.Debit, l.Credit))
            );

            return RedirectToPage();
        }
        public IActionResult OnPostAddRecieptLine()
        {
            // 1) compute totals without LINQ:
            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in RecieptLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }

            

            // 2) build the list of tuples manually (no Select)
            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in RecieptLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }

            // 3) call your helper
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.InsertReceiptVoucher(
                connString,
                ReceiptHeader.ReferenceNo,
                ReceiptHeader.VoucherDate,
                voucherLines
            );

            // 4) done
            return RedirectToPage();
        }
        public IActionResult OnPostDeleteReceipt(int receiptId)
        {
            // call the helper to run sp_ManageVoucher ... , @Action='Delete', @VoucherType='R'
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeleteReceiptVoucher(connString, receiptId);

            // reload the page so the updated list shows
            return RedirectToPage();
        }
        public IActionResult OnPostDeleteJournal(int journalId)
        {
            // call the helper to run sp_ManageVoucher ... , @Action='Delete', @VoucherType='R'
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeleteJournalVoucher(connString, journalId);

            // reload the page so the updated list shows
            return RedirectToPage();
        }
        public IActionResult OnPostDeletePayment(int paymentId)
        {
            // call the helper to run sp_ManageVoucher ... , @Action='Delete', @VoucherType='R'
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeletePaymentVoucher(connString, paymentId);

            // reload the page so the updated list shows
            return RedirectToPage();
        }



    }

}
