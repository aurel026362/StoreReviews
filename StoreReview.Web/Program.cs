using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using StoreReivew.Infrastracture.Data;

namespace StoreReview.Angular
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                //.MigrateDatabase<StoreReviewDbContext>()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
