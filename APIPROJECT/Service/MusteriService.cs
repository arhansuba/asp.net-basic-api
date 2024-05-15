using ASP.NET_API_EXAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPROJECT.Service
{
    public class MusteriService
    {
        private readonly MusteriDbContext _context;

        public MusteriService(MusteriDbContext context)
        {
            _context = context;
        }

        // Tüm müşterileri getir
        public async Task<List<MusteriYonetimSistemiAPI.Models.Musteri>> GetAllMusteriler()
        {
            return await _context.MusteriBilgileri.ToListAsync();
        }

        // ID'ye göre müşteri getir
        public async Task<MusteriYonetimSistemiAPI.Models.Musteri> GetMusteriById(int id)
        {
            return await _context.MusteriBilgileri.FindAsync(id);
        }

        // Yeni müşteri oluştur
        public async Task CreateMusteri(MusteriYonetimSistemiAPI.Models.Musteri musteri)
        {
            _context.MusteriBilgileri.Add(musteri);
            await _context.SaveChangesAsync();
        }

        // Müşteri bilgilerini güncelle
        public async Task UpdateMusteri(MusteriYonetimSistemiAPI.Models.Musteri musteri)
        {
            _context.Entry(musteri).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // ID'ye göre müşteri sil
        public async Task DeleteMusteri(int id)
        {
            var musteri = await _context.MusteriBilgileri.FindAsync(id);
            if (musteri != null)
            {
                _context.MusteriBilgileri.Remove(musteri);
                await _context.SaveChangesAsync();
            }
        }

        // Verilen şehirdeki müşterileri getir
        public async Task<List<MusteriYonetimSistemiAPI.Models.Musteri>> GetMusterilerByCity(string city)
        {
            return await _context.MusteriBilgileri.Where(m => m.Sehir == city).ToListAsync();
        }

        // Verilen ülkedeki müşterileri getir
        public async Task<List<MusteriYonetimSistemiAPI.Models.Musteri>> GetMusterilerByCountry(string country)
        {
            return await _context.MusteriBilgileri.Where(m => m.Ulke == country).ToListAsync();
        }

        // Verilen isme göre müşterileri ara
        public async Task<List<MusteriYonetimSistemiAPI.Models.Musteri>> SearchMusterilerByName(string searchTerm)
        {
            return await _context.MusteriBilgileri.Where(m => m.Ad.Contains(searchTerm) || m.Soyad.Contains(searchTerm)).ToListAsync();
        }

        // Müşterileri yaşa göre sırala
        public async Task<List<MusteriYonetimSistemiAPI.Models.Musteri>> SortMusterilerByAge()
        {
            return await _context.MusteriBilgileri.OrderBy(m => m.DogumTarihi).ToListAsync();
        }
    }
}
