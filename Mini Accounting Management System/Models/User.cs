using Microsoft.AspNetCore.Identity;

namespace Mini_Accounting_Management_System.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; } ="";
        public string Address { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
