using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace EfCoreSample.CodeFirst.DAL;

[Table("Catalogs")]
public class Catalog : IEntity
{
    [Key]
    public int Id { get; set; }
    [Column("CatalogName")]
    [Required]
    public string Name { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }  
    // Navigation property
    public virtual List<Product> Products { get; set; } = new List<Product>();
    public DateTime? DtCreated { get ; set  ; }
    public DateTime? DtUpdated { get; set  ; }
}
