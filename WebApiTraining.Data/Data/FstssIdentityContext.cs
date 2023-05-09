using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiTraining.Data.Data
{
    public class FstssIdentityContext : IdentityDbContext
    {
        public FstssIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
