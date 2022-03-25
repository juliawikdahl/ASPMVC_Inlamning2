using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_Inlamning_2.Models.Data
{
    public class AppDbContext : IdentityDbContext
    {
      
            public AppDbContext()
            {

            }

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public virtual DbSet<UserProfileEntity> UserProfiles { get; set; }
    }

    
}
