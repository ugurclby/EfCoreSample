using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreSample.CodeFirst.DAL;

[Table("Catalogs")]
public class Catalog
{
    [Key]
    public int Id { get; set; }
    [Column("CatalogName")]
    [Required]
    public string Name { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; } 
    public DateTime? DtCreated { get; set; }
    public DateTime? DtUpdated { get; set; }
    
    // Navigation property
    public List<Product> Products { get; set; }
}
