using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Accounting_Management_System.Models;

namespace Mini_Accounting_Management_System.Pages
{
    [Authorize(Roles ="Admin")]
    public class AdminModel : PageModel
    {
        private readonly UserManager<User> userManager;
        public User? appUser;
        public AdminModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            appUser = task.Result;
        }
    }
}
