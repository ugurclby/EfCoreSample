using AutoMapper.QueryableExtensions;
using EfCoreSample.CodeFirst.DAL;
using EfCoreSample.CodeFirst.Dtos;
using EfCoreSample.CodeFirst.MappingConfigration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Net.WebSockets;
using System.Reflection.Emit;
using System.Security.Cryptography;
DbContextInitializer.Build();

DbConnection dbConnection = new SqlConnection(DbContextInitializer.Configuration.GetConnectionString("DefaultConnection"));

using (var dbContext = new AppDbContext(dbConnection))
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

    //var firstProduct = dbContext.Products.First(x => x.Price > 500); // fiyatı 500 den büyük olan ilk ürünü getirir. Bulamazsa hata verir.

    //var firstProduct2 = dbContext.Products.FirstOrDefault(x => x.Price > 500); // fiyatı 500 den büyük olan ilk ürünü getirir. Bulamazsa null döner.

    //var singleProduct = dbContext.Products.Single(x => x.Id == 1); // id si 1 olan ürünü getirir. Bulamazsa hata verir ya da birden fazla varsa hata verir.

    //var singleProduct2 = dbContext.Products.SingleOrDefault(x => x.Id == 1); // id si 1 olan ürünü getirir. Bulamazsa null döner ya da birden fazla varsa hata verir.

    //var whereProduct = dbContext.Products.Where(x => x.Price > 500).ToList(); // fiyatı 500 den büyük olan tüm ürünleri getirir. Bulamazsa boş liste döner.

    #endregion

    #region İnsert-one-to-many
    //var catalogs = new Catalog { Name = "Kırtasiye", Description = "Kırtasiye ürünleri" };

    //var products = new List<Product>();

    //products.Add(new Product { Name = "Defter2", Description = "Defter2", Price = 100, Stock = 100, Kdv = 10 });
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
    //    Catalog_Id = catalog.Id,
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

    //Eager Loading

    //var catalog = dbContext.Catalogs.Include(x => x.Products).ThenInclude(x => x.ProductFeature).FirstOrDefault();

    //var products = dbContext.Products.Include(x => x.ProductFeature).Include(x => x.Catalog).ToList();

    //var productFeature = dbContext.ProductFeature.Include(x => x.Product).ThenInclude(x => x.Catalog).ToList();

    //Explicit Loading

    //var catalog2 = dbContext.Catalogs.First();

    //dbContext.Entry(catalog2).Collection(x => x.Products).Load();

    //var prodcuts2 = dbContext.Products.First();

    //dbContext.Entry(prodcuts2).Reference(x => x.ProductFeature).Load();

    //Lazy Loading

    //var catalog3 = dbContext.Catalogs.First(); // Bu aşamada product boş.

    //var products3 = catalog3.Products.ToList(); // Bu aşamada db ye gidip select çeker

    //foreach (var item in products3)
    //{
    //    var productFeature = item.ProductFeature; // Her loop da sorgu atacak. Performans sorunu olur. N+1 problemi denir.
    //}

    #endregion

    #region Inheritance
    //TPH: Table Per Hierarchy

    //dbContext.Bikes.Add(new Bike { Name = "Bisiklet", Model = "TestModeli", Wheels = 2 });
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

    #endregion

    #region Query 
    //var customer = new List<Customer>() {
    //        new Customer (){
    //        FullName = "Ali Yılmaz",
    //        Email = "ali.yilmaz@example.com",
    //        Phone = "555-1234",
    //        Address = "İstanbul, Türkiye"

    //    },new Customer (){
    //    FullName = "Test Yılmaz",
    //        Email = "ali.yilmaz@example.com",
    //        Phone = "555-1234",
    //        Address = "İstanbul, Türkiye"}
    //    ,new Customer (){
    //    FullName = "Test2 Yılmaz",
    //        Email = "ali.yilmaz@example.com",
    //        Phone = "555-1234",
    //        Address = "İstanbul, Türkiye"}
    //};

    //    var customer = new List<Customer>() {
    //        new Customer (){
    //        FullName = "Test3 Yılmaz",
    //        Email = "ali.yilmaz@example.com",
    //        Phone = "555-1234",
    //        Address = "İstanbul, Türkiye" } };

    //dbContext.Customers.AddRange(customer);


    //var orders = new List<Order>() {
    //    new Order (){
    //    CustomerId = 1,
    //    TotalAmount = 100,
    //    Status = "Onaylandı"
    //},new Order (){
    //    CustomerId = 1,
    //    TotalAmount = 200,
    //    Status = "Onaylandı"
    //},new Order (){
    //    CustomerId = 2,
    //    TotalAmount = 300,
    //    Status = "Onaylandı"}
    //,new Order (){
    //    CustomerId = 3,
    //    TotalAmount = 300,
    //    Status = "Onaylandı"}};

    //dbContext.Orders.AddRange(orders);


    //var orderDetails = new List<OrderDetail>() {
    //    new OrderDetail (){
    //    ProductName = "Ürün 1",
    //    Quantity = 1,
    //    UnitPrice = 100,
    //    OrderId = 1

    //},new OrderDetail (){
    //    ProductName = "Ürün 2",
    //    Quantity = 2,
    //    UnitPrice = 200,
    //    OrderId = 2
    //},new OrderDetail (){
    //    ProductName = "Ürün 3",
    //    Quantity = 3,
    //    UnitPrice = 300,
    //    OrderId = 3} };

    //dbContext.OrderDetails.AddRange(orderDetails);

    //dbContext.SaveChanges();
    #region InnerJoin

    // Metod Sytanx : 
    //var metodJoin = dbContext.Customers.Join(dbContext.Orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new { c, o })
    //                   .Join(dbContext.OrderDetails, o => o.o.OrderId, od => od.OrderId, (o, od) => new { o, od }).ToList();

    //// Query Syntax :
    //var sqlJoin = (from c in dbContext.Customers
    //               join o in dbContext.Orders on c.CustomerId equals o.CustomerId
    //               join od in dbContext.OrderDetails on o.OrderId equals od.OrderId
    //               select new { c, o, od }).ToList();

    #endregion

    #region Left-Right Join


    // Query Syntax :
    //var leftJoin = (from c in dbContext.Customers
    //                join o in dbContext.Orders on c.CustomerId equals o.CustomerId into oList
    //                from olist in oList.DefaultIfEmpty()
    //                select new { c, olist }).ToList();

    //// Metod Sytanx :
    //var left2 = dbContext.Customers.GroupJoin(dbContext.Orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new { c, o })
    //    .SelectMany(x => x.o.DefaultIfEmpty(), (x, y) => new { x.c, y }).ToList();


    //var rightJoin = (from o in dbContext.Orders
    //                 join c in dbContext.Customers on o.CustomerId equals c.CustomerId into cList
    //                 from clist in cList.DefaultIfEmpty()
    //                 select new { o, clist }).ToList();

    #endregion

    #region Full-Outer Join

    //var left = (from c in dbContext.Customers
    //            join o in dbContext.Orders on c.CustomerId equals o.CustomerId into oList
    //            from olist in oList.DefaultIfEmpty()
    //            select new { OrderId = (int?)olist.OrderId, CustomerId = (int?)olist.CustomerId, Name = c.FullName }).ToList();

    //var right = (from o in dbContext.Orders
    //             join c in dbContext.Customers on o.CustomerId equals c.CustomerId into cList
    //             from clist in cList.DefaultIfEmpty()
    //             select new { OrderId = (int?)o.OrderId, CustomerId = (int?)o.CustomerId, Name = clist.FullName }).ToList();

    //var fullOuter = left.Union(right).ToList();


    #endregion

    #region RawSql-1

    //var customers = dbContext.Customers.FromSqlRaw("SELECT * FROM Customers").ToList();

    //var customer = dbContext.Customers.FromSqlRaw("SELECT * FROM Customers WHERE CustomerId = {0}", 1).ToList();

    //var order = dbContext.Orders.FromSqlInterpolated($"SELECT * FROM Orders WHERE CustomerId = {1}").ToList();


    //var customerWithOrder = dbContext.CustomerWithOrders.FromSqlRaw("SELECT c.CustomerId,c.FullName,c.Email,o.TotalAmount FROM Customers c inner join orders o on c.CustomerId=o.CustomerId").ToList();

    #endregion

    #region ToSqlQuery

    //var orderWithOrderDetails = dbContext.OrderWithDetails.ToList(); // Sorgusu direkt onmodelcreating tarafında yazıldı.
    //var orderWithOrderDetails2 = dbContext.OrderWithDetails.Where(x => x.OrderId == 1).ToList(); // Db ye direkt kriter ile gider.

    #endregion

    #endregion

    #region ToView
    //var vCustomersWithOrders = dbContext.VCustomersWithOrders.ToList();

    #endregion

    #region ToTable
    //var user = dbContext.User.ToList();
    #endregion

    #region Global Query Filter 
    //onmodelcreating tarafında tanımlanan query filter çalışır. 
    //var customers = dbContext.Customers.ToList();

    //var customer = dbContext.Customers.IgnoreQueryFilters().ToList(); // Query filteri kaldırır.
    #endregion

    #region TagWith

    //var customersTag = dbContext.Customers.TagWith("This is a tag query").ToList();


    #endregion

    #region Store Procedure

    // Geriye select dönen store procedure fromsqlraw ile çalıştırılır. View gibi.
    // Geriye int ya da hiç bir şey dönmeyen prosedür :

    //var customersp = new Customer()
    //{
    //    FullName = "Uğur",
    //    Email = "asd",
    //    Phone = "123",
    //    Address = "asd",
    //    CreatedAt = DateTime.Now,
    //    IsDeleted = false
    //};

    //var newidParameter = new SqlParameter("@newId", SqlDbType.Int)
    //{
    //    Direction = ParameterDirection.Output
    //};

    //var result = dbContext.Database.ExecuteSqlInterpolated(@$"EXEC usp_InsertCustomer {customersp.FullName},{customersp.Email},{customersp.Phone},{customersp.Address},{customersp.CreatedAt} ,{customersp.IsDeleted}, {newidParameter} out;");

    #endregion

    #region Function

    // Geriye table dönen ve parametre almayan fonksiyonlar view gibi çalışır. Onmodelcreating tarafında tanımlanır.
    //var fcuser = dbContext.FcUser.ToList();

    //// Geriye table dönen ve parametre alan fonksiyonlar fromsqlinterpolated ile çalıştırılır ya da onmodelcreating tarafında hasfunction ile tanımlanır.
    //var fcuser2 = dbContext.FcUser.FromSqlInterpolated($"SELECT * FROM dbo.fc_GetUsersParam(1)").ToList();

    //var fcuser3 = dbContext.GetFcUsers(1).ToList();

    ////var count = dbContext.GetFcUsersCount(1); // bu şekilde çağırıldığı zaman hata verir.
    //// Geriye int ya da string dönen fonksiyonlar scalar olarak çalışır.
    //var users = dbContext.User.Select(x => new
    //{
    //    Name = x.Name,
    //    Count = dbContext.GetFcUsersCount(x.Id) // Geriye int dönen fonksiyon on model creating altında tanımlanır ve sadece bu şekilde çalıştırılır.
    //});

    //// Eğer direkt fonksiyon tek başına çağırılmak isteniyorsa model ile mapplemek gerekir.
    //var userCount = dbContext.Count.FromSqlInterpolated($"SELECT dbo.fc_GetUsersParamCount(1) as Count").First().Count;

    #endregion

    #region Projections

    // Anonymous Type
    var customers = dbContext.Customers.Select(x => new { x.FullName, x.Email }).ToList();

    // Dto
    var customers2 = dbContext.Customers.Select(x => new CustomerDto { CustomerId=x.CustomerId,CustomerEmail=x.Email,CustomerName=x.FullName}).ToList();

    // AutoMapper

    var customer3 = dbContext.Customers.ToList();

    var cst = ObjectMapper.Mapper().Map<List<CustomerDto>>(customer3);

    var customers4 = dbContext.Customers.ProjectTo<CustomerDto>(ObjectMapper.Mapper().ConfigurationProvider).Where(x=>x.CustomerId>5) .ToList();


    #endregion

    #region Transaction
    
    // Tek dbcontext üzerinden transaction işlemi yapılır.
    //using (var transaction = dbContext.Database.BeginTransaction())
    //{
    //    dbContext.User.Add(new Users
    //    {
    //        Name = "Uğur"
    //    });

    //    dbContext.SaveChanges(); // burada id alır. Fakat db ye yansıma işi yapılmaz.

    //    dbContext.Catalogs.Add(new Catalog
    //    {
    //        Name = "Spor",
    //        Description = "Spor ürünleri" 
    //    });

    //    dbContext.SaveChanges(); // burada id alır. Fakat db ye yansıma işi yapılmaz. 

    //    transaction.Commit(); // işlemler başarılı ise db ye yansıtılır.
    //}

    // Birden fazla dbcontext üzerinden transaction işlemi yapılır.
    using (var transaction = dbContext.Database.BeginTransaction())
    {
        dbContext.User.Add(new Users
        {
            Name = "Uğur2"
        });
        dbContext.SaveChanges();
        dbContext.Catalogs.Add(new Catalog
        {
            Name = "Araba",
            Description = "Araba ürünleri"
        });
        dbContext.SaveChanges();

        using (var dbcontext2 = new AppDbContext(dbConnection))
        {
            var trans = transaction.GetDbTransaction();
            dbcontext2.Database.UseTransaction(trans);

            dbcontext2.Students.Add(new Student { DtCreated = DateTime.Now, Email = "asd", Name = "asd" });
            dbcontext2.SaveChanges();

        } 

        transaction.Commit(); 
    }

    #endregion

}
//#region Pagination 

//var customerList = GetCustomers(1, 5);

//foreach (var customer in customerList)
//{
//    Console.WriteLine(customer.FullName);
//}
//static List<Customer> GetCustomers(int page, int pageSize)
//{
//    using (var dbContext = new AppDbContext())
//    {
//        //page : 1 = > 0 dan başla pagesize kadar getir
//        //page : 2 = > 2-1 * pagesize kadar atla ve pagesize kadar getir
//        //page : 3 = > 3-1 * pagesize kadar atla ve pagesize kadar getir
//        // Skip : atlanacak kayıt sayısı
//        // Take : alınacak kayıt sayısı
//        return dbContext.Customers.OrderByDescending(x=>x.CustomerId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
//    }
//}
//#endregion