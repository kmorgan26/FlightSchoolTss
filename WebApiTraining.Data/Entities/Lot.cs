using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Entities
{
    public class Lot : BaseEntity
    {
        public int PlatformId { get; set; }
        public virtual ICollection<ManModule>? ManModules { get; set; }
    }
}