
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DAL.Database
{
  public class IdentityContext : IdentityDbContext<AppUser>
{
        //Add-Migration InitialIdentity -c IdentityDbContext -o Identity/Migrations
        //Update-Database -Context IdentityContext
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        
        }
}
}
