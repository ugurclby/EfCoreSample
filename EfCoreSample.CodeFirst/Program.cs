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

    /* Console.WriteLine(dbContext.ContextId); */ // birden fazla context oluşturulduğunda her biri için farklı bir id oluşturulur.

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

    #region İnsert-one-to-many
    //var catalogs = new Catalog { Name = "Kırtasiye", Description = "Kırtasiye ürünleri" };

    //var products = new List<Product>();

    //products.Add(new Product { Name = "Defter2", Description = "Defter2", Price = 100, Stock = 100,Kdv=10 });
    //products.Add(new Product { Name = "Kalem2", Description = "Kalem2", Price = 200, Stock = 1100, Kdv = 10 });

    //catalogs.Products.AddRange(products);

    //dbContext.Catalogs.Add(catalogs);

    //dbContext.SaveChanges();
    #endregion

    #region İnsert-one-to-one

    //var catalog = await dbContext.Catalogs.Where(x => x.Name == "Kırtasiye").FirstOrDefaultAsync(); 

    //var products = new List<Product>();

    //products.Add(new Product
    //{
    //    Name = "Kitap",
    //    Description = "Kitap",
    //    Price = 300,
    //    Stock = 500,
    //    Catalog_Id  = catalog.Id,
    //    ProductFeature = new()
    //    {
    //        Height = 100,
    //        Width = 200
    //    }
    //});

    //products.AddRange(products);

    //await dbContext.Products.AddRangeAsync(products);

    //dbContext.SaveChanges();
    #endregion

    #region İnsert-Many-to-Many

    //var students = new List<Student>();

    //students.Add(new Student
    //{
    //    Name = "Öğrenci 1",
    //    Email = "asd@asd.com",
    //    Teachers = new List<Teacher>() {
    //new Teacher { Name = "Öğretmen 1",Email="qwe@qwe.com" },
    // new Teacher { Name = "Öğretmen 2",Email="qwe2@qwe.com" }
    //}
    //});
    //students.Add(new Student
    //{
    //    Name = "Öğrenci 2",
    //    Email = "asd2@asd.com",
    //    Teachers = new List<Teacher>() {
    //new Teacher { Name = "Öğretmen 3",Email="qwe3@qwe.com" },
    // new Teacher { Name = "Öğretmen 4",Email="qwe4@qwe.com" }
    //}
    //});

    //dbContext.Students.AddRange(students);

    //dbContext.SaveChanges();    

    #endregion

    #region Delete-Behavior-İşlemleri
    //try
    //{
    //    dbContext.Catalogs.Remove(dbContext.Catalogs.First());

    //    dbContext.SaveChanges();
    //}
    //catch (Exception ex)
    //{

    //    Console.WriteLine(ex.InnerException.Message);
    //}


    #endregion

    #region Related-Data-Load

    // Eager Loading

    //var catalog = dbContext.Catalogs.Include(x => x.Products).ThenInclude(x => x.ProductFeature).FirstOrDefault();

    //var products = dbContext.Products.Include(x => x.ProductFeature).Include(x=>x.Catalog).ToList();

    //var productFeature = dbContext.ProductFeature.Include(x => x.Product).ThenInclude(x=>x.Catalog).ToList();

    // Explicit Loading

    //var catalog2 = dbContext.Catalogs.First();

    //dbContext.Entry(catalog2).Collection(x => x.Products).Load();

    //var prodcuts2 = dbContext.Products.First();

    //dbContext.Entry(prodcuts2).Reference(x => x.ProductFeature).Load();

    // Lazy Loading

    //var catalog3 = dbContext.Catalogs.First(); // Bu aşamada product boş.

    //var products3 = catalog3.Products.ToList(); // Bu aşamada db ye gidip select çeker

    //foreach (var item in products3)
    //{
    //    var productFeature = item.ProductFeature; // Her loop da sorgu atacak. Performans sorunu olur. N+1 problemi denir.
    //}

    #endregion

    #region Inheritance
    // TPH : Table Per Hierarchy

    //dbContext.Bikes.Add(new Bike { Name = "Bisiklet",Model="TestModeli",Wheels=2});
    //dbContext.SportsCars.Add(new SportsCar { Name = "Ferrari", Model = "TestModeli", Speed = "400" });

    //dbContext.SaveChanges();

    //var vehicles = dbContext.Vehicles.ToList();

    //vehicles.ForEach(x =>
    //{
    //    switch (x)
    //    {
    //        case Bike bike:
    //            Console.WriteLine("Bike");
    //            break;
    //        case SportsCar sportsCar:
    //            Console.WriteLine("Car");
    //            break;
    //        default:
    //            break;
    //    }
    //});

    // TPT : Table Per Type


    #endregion

}





