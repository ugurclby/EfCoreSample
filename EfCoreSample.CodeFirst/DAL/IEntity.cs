using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public interface IEntity
{
    public DateTime? DtCreated { get; set; }
    public DateTime? DtUpdated { get; set; }
}
