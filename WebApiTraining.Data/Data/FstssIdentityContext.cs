using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiTraining.Data.Data
{
    public class FstssIdentityContext : IdentityDbContext<FstssUser>
    {
        public FstssIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
