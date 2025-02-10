using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public class ProductFeature : IEntity
{
    public int Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; } 
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public DateTime? DtCreated { get; set ; }
    public DateTime? DtUpdated { get ; set ; }
}
