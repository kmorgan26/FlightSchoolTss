using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSchoolTss.Data.Abstractions;
public abstract class BaseDtoViewModel
{
    public abstract int Id { get; set; }
    public string Name { get; set; } = null!;
}
