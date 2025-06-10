using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Accounting_Management_System.db.Tables;
using Mini_Accounting_Management_System.DTO;
using Mini_Accounting_Management_System.Helper;

namespace Mini_Accounting_Management_System.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }
        public List<AccountTypeDTO> AccountTypes { get; set; } = new();
        public List<SubAccountDTO> SubAccounts { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public int? TypeFilter { get; set; }
        [BindProperty]
        public string? AccountTypeName { get; set; }
        [BindProperty]
        public string? NewSubAccName { get; set; }
        [BindProperty]
        public decimal NewSubBalance { get; set; }
        [BindProperty]
        public int Sub_id { get; set; }
        public void OnGet()
        {
            string connString = _config.GetConnectionString("DefaultConnection");
            AccountTypes = AccountHelper.GetAccountType(connString);

           
            if (TypeFilter.HasValue)
            {
                SubAccounts = AccountHelper.GetSubAccountsByType(connString, TypeFilter.Value);
            }
        }
     
        public IActionResult OnPostFilterByType(int? TypeFilter)
        {
            if (!TypeFilter.HasValue)
            {
                
                return RedirectToPage();
            }

            
            return RedirectToPage(new { TypeFilter = TypeFilter.Value });
        }

        public IActionResult OnpostWholeAccount()
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            string connString = _config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(AccountTypeName))
            {
                return RedirectToPage();
            }
            int newType = AccountHelper.InsertWholeAccount(connString, AccountTypeName);
            return RedirectToPage();
        }
        public IActionResult OnPostAddSubAccount()
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            if (TypeFilter == null || string.IsNullOrWhiteSpace(NewSubAccName))
            {
                return RedirectToPage(new { TypeFilter });
            }

            
            string connString = _config.GetConnectionString("DefaultConnection")!;
            int newSubPId = AccountHelper.InsertSubAccount(
                connString,
                TypeFilter.Value,
                NewSubAccName,
                NewSubBalance
            );

            
            return RedirectToPage(new { TypeFilter });
        }
        public IActionResult OnPostDeleteSubAccount() 
        {
            if (User.IsInRole("Viewer"))
            {
                return Forbid();
            }
            if (!TypeFilter.HasValue|| Sub_id <= 0)
            {
                return RedirectToPage(new { TypeFilter });
            }
            string connString = _config.GetConnectionString("DefaultConnection")!;
            int del= AccountHelper.DeleteSubAccount(connString, Sub_id);
            return RedirectToPage(new {TypeFilter});
        }
    }
}
