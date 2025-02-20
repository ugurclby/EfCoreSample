using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public sealed class AppDbContext:DbContext
{
    private readonly DbConnection _dbConnection;

    public AppDbContext()
    {
            
    }
    public AppDbContext(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public DbSet<Product> Products { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
    public DbSet<Student> Students{ get; set; } 
    public DbSet<ProductFeature> ProductFeature { get; set; }
    public DbSet<Vehicle> Vehicles{ get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<SportsCar> SportsCars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<CustomerWithOrder> CustomerWithOrders { get; set; }

    public DbSet<OrderWithDetail> OrderWithDetails { get; set; }

    public DbSet<VCustomersWithOrders> VCustomersWithOrders { get; set; }

    public DbSet<Users> User { get; set; }

    public DbSet<FcUsers> FcUser { get; set; }

    public DbSet<UserCount> Count { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_dbConnection ==null)
        {
            DbContextInitializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                          .UseLazyLoadingProxies()
                          .UseSqlServer(_dbConnection);
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
        }
        else
        {
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                          .UseLazyLoadingProxies()
                          .UseSqlServer(_dbConnection);
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("ProductsTb");
        modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired(true).HasMaxLength(100);
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]"); 



        modelBuilder.Entity<Catalog>().HasMany(x => x.Products).WithOne(x => x.Catalog).HasForeignKey(x => x.Catalog_Id).OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductId);

        modelBuilder.Entity<Teacher>().HasMany(x => x.Students).WithMany(x => x.Teachers).UsingEntity<Dictionary<string, object>>(
            "TeacherStudent",
            x => x.HasOne<Student>().WithMany().HasForeignKey("Student_Id"),
            x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id")
            );

        modelBuilder.Entity<Vehicle>().HasDiscriminator<string>("VehicleType")
            .HasValue<Vehicle>("Vehicle")
            .HasValue<Bike>("Bike")
            .HasValue<SportsCar>("SportsCar");


        modelBuilder.Entity<CustomerWithOrder>().HasNoKey().ToView(null);

        modelBuilder.Entity<OrderWithDetail>().HasNoKey().ToSqlQuery("SELECT od.OrderDetailId,od.OrderId,o.OrderDate,o.TotalAmount,od.ProductName FROM Orders o inner join OrderDetails od on o.OrderId = od.OrderId");


        modelBuilder.Entity<VCustomersWithOrders>().HasNoKey().ToView("VCustomersWithOrders");

        modelBuilder.Entity<Users>().ToTable("User");

        modelBuilder.Entity<Customer>().Property(x => x.IsDeleted).HasDefaultValue(false);
        
        modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);

        modelBuilder.Entity<FcUsers>().ToFunction("fc_GetUsers");

        modelBuilder.HasDbFunction( typeof(AppDbContext).GetMethod(nameof(GetFcUsers), new[] { typeof(int) })!).HasName("fc_GetUsersParam");

        modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetFcUsersCount), new[] { typeof(int) })!).HasName("fc_GetUsersParamCount");

        modelBuilder.Entity<UserCount>().HasNoKey();

        base.OnModelCreating(modelBuilder);
    }

    public IQueryable<FcUsers> GetFcUsers(int userId)
    {
        return FromExpression(() => GetFcUsers(userId));
    }

    public int GetFcUsersCount(int userId)
    {
       throw new NotSupportedException("Bu metod ef core tarafından kullanılıyor");
    }

    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is IEntity p)
            {
                if (item.State == EntityState.Added)
                {
                    p.DtCreated = DateTime.UtcNow;
                }
                else
                {
                    p.DtUpdated = DateTime.UtcNow;

                }
            }
        };
        return base.SaveChanges();
    }
}
