using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IU2Andres.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
