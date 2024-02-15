using Homezmart.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homezmart.Models.DatabaseContext
{
    public class IdentityDBContext: IdentityDbContext<AppUser> 
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
            :base(options)
        {
            
        }
    }
}
