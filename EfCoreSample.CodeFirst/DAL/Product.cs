using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL; 
public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public DateTime? DtCreated { get; set; }
    public DateTime? DtUpdated { get; set; }
    public int Kdv { get; set; }
    public decimal PriceKdv { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime FirstAccess { get; set; } = DateTime.Now;
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastsAccess { get; set; } = DateTime.Now;


    // Foreign key
    public int Catalog_Id { get; set; }
    
    // Navigation property
    public virtual Catalog Catalog { get; set; }

    public virtual ProductFeature ProductFeature { get; set; }
}
