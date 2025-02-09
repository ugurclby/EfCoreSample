using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL; 
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public DateTime? DtCreated { get; set; }
    public DateTime? DtUpdated { get; set; }
    
    // Foreign key
    public int Catalog_Id { get; set; }
    
    // Navigation property
    public Catalog Catalog { get; set; }

    public ProductFeature ProductFeature { get; set; }
}
