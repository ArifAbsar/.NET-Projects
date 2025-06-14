using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Mini_Accounting_Management_System.DTO;
using Mini_Accounting_Management_System.Helper;
using Mini_Accounting_Management_System.Models;

namespace Mini_Accounting_Management_System.Pages
{
    [Authorize(Roles ="Admin")]
    public class AdminModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration _config;
        public List<UserRoleDTO> Users { get; set; } = new();

        public List<RoleDTO> AllRoles { get; set; } = new();
        public AdminModel(UserManager<User> userManager,IConfiguration config)
        {
            this.userManager = userManager;
            _config = config;
        }
        [BindProperty]
        public string SelectedUserName { get; set; } = "";
        [BindProperty]
        public string SelectedRoleId { get; set; } = "";

        [BindProperty]
        public string SelectedRoleName { get; set; } = "";
        public void OnGet()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection")!;
            var allUsers = AccountHelper.GetAllUsersWithRoles(connectionString);
            Users = new List<UserRoleDTO>();
            var current = User.Identity?.Name ?? "";

            foreach (var u in allUsers)
            {
                if (!u.UserName.Equals(current, StringComparison.OrdinalIgnoreCase))
                {
                    Users.Add(u);
                }
            }
            
            AllRoles = AccountHelper.GetAllRoles(connectionString);
        }
        public IActionResult OnPostAssignRole()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection")!;
            
            
                AccountHelper.AssignUserRoleByName(connectionString,
                    User.Identity!.Name!,
                    SelectedUserName,
                    SelectedRoleName
                );
                TempData["Success"] = $"Assigned {SelectedRoleName} to {SelectedUserName}.";


            return RedirectToPage();
        }
    }
}
