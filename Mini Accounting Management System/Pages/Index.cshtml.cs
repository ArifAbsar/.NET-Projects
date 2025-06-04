using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Accounting_Management_System.DTO;
using Mini_Accounting_Management_System.Helper;

namespace Mini_Accounting_Management_System.Pages
{
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
        public string? TypeFilter { get; set; }
        public void OnGet()
        {
            string connString = _config.GetConnectionString("DefaultConnection");

            // 1) Always load distinct account types
            AccountTypes = AccountHelper.GetAccountType(connString);

            // 2) If the user clicked a type (e.g. ?type=Asset), load sub-accounts
            if (!string.IsNullOrWhiteSpace(TypeFilter))
            {
                SubAccounts = AccountHelper.GetSubAccountsByType(connString, TypeFilter);
            }
        }
    }
}
