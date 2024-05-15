using MusteriYonetimSistemiAPI.Models;

namespace APIPROJECT.Service
{
    public interface IMusteriService
    {
        Task<List<Musteri>> GetAllMusteriler();
        Task<Musteri> GetMusteriById(int id);
        Task CreateMusteri(Musteri musteri);
        Task UpdateMusteri(Musteri musteri);
        Task DeleteMusteri(int id);
        Task<List<Musteri>> GetMusterilerByCity(string city);
        Task<List<Musteri>> GetMusterilerByCountry(string country);
        Task<List<Musteri>> SearchMusterilerByName(string searchTerm);
        Task<List<Musteri>> SortMusterilerByAge();
    }
}
