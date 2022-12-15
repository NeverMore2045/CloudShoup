using CloudShoup.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShoup.Models
{
    public class ShoupDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключания
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("CloudDbConnect"));
        }
    }
}
