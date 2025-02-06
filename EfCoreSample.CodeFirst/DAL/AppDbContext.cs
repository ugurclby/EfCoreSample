﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.CodeFirst.DAL;
public sealed class AppDbContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        DbContextInitializer.Build();
        optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("ProductsTb");
        modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired(true).HasMaxLength(100);
        modelBuilder.Entity<Product>().HasKey(x => x.Id);


        modelBuilder.Entity<Catalog>().HasMany(x => x.Products).WithOne(x => x.Catalog).HasForeignKey(x => x.Catalog_Id); 

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is Product p)
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
