using EfCoreSample.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
DbContextInitializer.Build();

using (var dbContext = new AppDbContext())
{
    #region ChangeTracker & Merkezi Insert,update , ContextId

    //insert atarken DtCreated dbcontext altında ezilerek set edilir

    //dbContext.Add(new Product() { Name = "Defter", Price = 200, Stock = 100, Description = "Deneme" });
    //dbContext.Add(new Product() { Name = "Kalem", Price = 100, Stock = 200, Description = "Deneme" });
    //dbContext.Add(new Product() { Name = "Silgi", Price = 50, Stock = 300, Description = "Deneme" });
    //dbContext.Add(new Product() { Name = "Araba", Price = 2000, Stock = 20, Description = "Deneme" });

    //update atarken DtUpdated dbcontext altında ezilerek set edilir

    //var products = dbContext.Products.ToList();

    //foreach (var product in products)
    //{
    //    product.Stock += 10;
    //}

    Console.WriteLine(dbContext.ContextId);  // birden fazla context oluşturulduğunda her biri için farklı bir id oluşturulur.

    dbContext.SaveChanges();
    #endregion

    #region DbSet Methods

    //var findProduct = dbContext.Products.Find(1); // Tablodaki pk alanına direkt sorgulama yapar. bulmazsa null döner.

    //var products = dbContext.Products.ToList(); // Tüm ürünleri getirir

    //var firstProduct = dbContext.Products.First(x=>x.Price>500); // fiyatı 500 den büyük olan ilk ürünü getirir. Bulamazsa hata verir.

    //var firstProduct2 = dbContext.Products.FirstOrDefault(x => x.Price > 500); // fiyatı 500 den büyük olan ilk ürünü getirir. Bulamazsa null döner.

    //var singleProduct = dbContext.Products.Single(x => x.Id == 1); // id si 1 olan ürünü getirir. Bulamazsa hata verir ya da birden fazla varsa hata verir.

    //var singleProduct2 = dbContext.Products.SingleOrDefault(x => x.Id == 1); // id si 1 olan ürünü getirir. Bulamazsa null döner ya da birden fazla varsa hata verir.

    //var whereProduct = dbContext.Products.Where(x => x.Price > 500).ToList(); // fiyatı 500 den büyük olan tüm ürünleri getirir. Bulamazsa boş liste döner.

    #endregion



}





