using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Mini_Accounting_Management_System.DTO;
using System.Data;
using System.Drawing;
using Mini_Accounting_Management_System.Helper;
using Microsoft.AspNetCore.Authorization;
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
        public PaymentHeader PaymentHeader { get; set; } = new();

        public decimal JournalTotalDebit
        {
            get
            {
                decimal total = 0;
                foreach (var v in JournalVouchers)
                {
                    total += v.Debit;
                }
                return total;
            }
        }
        public decimal JournalTotalCredit
        {
            get
            {
                decimal total = 0;
                foreach (var v in JournalVouchers)
                {
                    total += v.Credit;
                }
                return total;
            }
        }

        public decimal PaymentTotalDebit
        {
            get
            {
                decimal total = 0;
                foreach (var v in PaymentVouchers)
                {
                    total += v.Debit;
                }
                return total;
            }
        }
        public decimal PaymentTotalCredit
        {
            get
            {
                decimal total = 0;
                foreach (var v in PaymentVouchers)
                {
                    total += v.Credit;
                }
                return total;
            }
        }
        public decimal ReceiptTotalDebit
        {
            get
            {
                decimal total = 0;
                foreach (var v in ReceiptVouchers)
                {
                    total += v.Debit;
                }
                return total;
            }
        }
        public decimal ReceiptTotalCredit
        {
            get
            {
                decimal total = 0;
                foreach (var v in ReceiptVouchers)
                {
                    total += v.Credit;
                }
                return total;
            }
        }

        [BindProperty]
        public RecieptHeader ReceiptHeader { get; set; } = new();
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
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }

            string connString = _config.GetConnectionString("DefaultConnection");

            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in JournalLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }

            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in JournalLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }

            AccountHelper.InsertJournalVoucher(
                connString,
                JournalHeader.ReferenceNo,
                JournalHeader.VoucherDate,
                voucherLines
            );

            return RedirectToPage();
        }

        public IActionResult OnPostAddPaymentLine()
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }

            string connString = _config.GetConnectionString("DefaultConnection");
            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in PaylLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }

            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in PaylLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }

            AccountHelper.InsertPaymentVoucher(
                connString,
                PaymentHeader.ReferenceNo,
                PaymentHeader.VoucherDate,
                voucherLines
            );

            return RedirectToPage();
        }

        public IActionResult OnPostAddRecieptLine()
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }

            decimal totalDebit = 0m;
            decimal totalCredit = 0m;
            foreach (var line in RecieptLines)
            {
                totalDebit += line.Debit;
                totalCredit += line.Credit;
            }

            var voucherLines = new List<(int SubAccountID, decimal Debit, decimal Credit)>();
            foreach (var line in RecieptLines)
            {
                voucherLines.Add((line.SubAccountID, line.Debit, line.Credit));
            }

            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.InsertReceiptVoucher(
                connString,
                ReceiptHeader.ReferenceNo,
                ReceiptHeader.VoucherDate,
                voucherLines
            );

            return RedirectToPage();
        }

        public IActionResult OnPostDeleteReceipt(int receiptId)
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeleteReceiptVoucher(connString, receiptId);

            return RedirectToPage();
        }

        public IActionResult OnPostDeleteJournal(int journalId)
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeleteJournalVoucher(connString, journalId);

            return RedirectToPage();
        }

        public IActionResult OnPostDeletePayment(int paymentId)
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            string connString = _config.GetConnectionString("DefaultConnection")!;
            AccountHelper.DeletePaymentVoucher(connString, paymentId);

            return RedirectToPage();
        }
    }

}
