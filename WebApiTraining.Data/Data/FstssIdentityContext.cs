using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTraining.Data.Data
{
    public class FstssIdentityContext : IdentityDbContext
    {
        public FstssIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
