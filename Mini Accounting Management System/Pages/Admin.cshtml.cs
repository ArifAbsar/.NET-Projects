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
        public string SelectedRoleName { get; set; } = "";
        public void OnGet()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection")!;
            Users = AccountHelper.GetAllUsersWithRoles(connectionString);
            AllRoles = AccountHelper.GetAllRoles(connectionString);
        }
        public IActionResult OnPostAssignRole()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection")!;
            try
            {
                AccountHelper.AssignUserRoleByName(connectionString,
                    User.Identity!.Name!,
                    SelectedUserName,
                    SelectedRoleName
                );
                TempData["Success"] = $"Assigned {SelectedRoleName} to {SelectedUserName}.";
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            OnGet();
            return Page();
        }
    }
}
