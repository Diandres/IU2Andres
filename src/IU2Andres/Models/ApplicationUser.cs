using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IU2Andres.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
