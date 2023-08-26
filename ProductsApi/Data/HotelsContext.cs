using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using ProductsApi.Models.HotelModels;


namespace ProductsApi.Data
{
    public class HotelsContext : DbContext
    {
        public HotelsContext(DbContextOptions<HotelsContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        // Lista da classe que irá para o banco
        public DbSet<Hotel> Hotels { get; set; } 
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
