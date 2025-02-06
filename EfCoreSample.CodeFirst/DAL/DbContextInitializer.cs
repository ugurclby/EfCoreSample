using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCoreSample.CodeFirst.DAL;
public class DbContextInitializer
{
    public static IConfiguration Configuration=default!;
    public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder = default!; 
    public static void Build()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build(); 

        //var connectionString = Configuration.GetConnectionString("DefaultConnection");
        //OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //OptionsBuilder.UseSqlServer(connectionString);
    }

}
