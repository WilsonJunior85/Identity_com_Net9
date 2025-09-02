using Microsoft.AspNetCore.Identity;

namespace Identity_com_Net9.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}
