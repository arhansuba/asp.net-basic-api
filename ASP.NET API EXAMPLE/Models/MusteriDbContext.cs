using Microsoft.EntityFrameworkCore;
using MusteriYonetimSistemiAPI.Models;

namespace ASP.NET_API_EXAMPLE.Models
{
    public class MusteriDbContext:DbContext
    {
        public MusteriDbContext(DbContextOptions<MusteriDbContext> options) : base(options) { }
        public DbSet<Musteri> MusteriBilgileri { get; set; }
    }
}
