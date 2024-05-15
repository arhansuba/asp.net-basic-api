using System.Text.Json;
using MVCProject.Models;

namespace MVCProject.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<MusteriViewModel>> GetMusterilerAsync()
        {
            List<MusteriViewModel>? musteriler = null;

            HttpResponseMessage response = await _httpClient.GetAsync("api/Musteri/Index");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                musteriler = JsonSerializer.Deserialize<List<MusteriViewModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return musteriler;
        }

        public async Task<MusteriViewModel> GetMusteriByIdAsync(int id)
        {
            MusteriViewModel? musteri = null;

            HttpResponseMessage response = await _httpClient.GetAsync($"api/Musteri/Details?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                musteri = JsonSerializer.Deserialize<MusteriViewModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return musteri;
        }

       
    }
}
