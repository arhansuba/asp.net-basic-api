using MVCProject.Models;

namespace MVCProject.Services
{
    public interface IApiService
    {
        Task<List<MusteriViewModel>> GetMusterilerAsync();
        Task<MusteriViewModel> GetMusteriByIdAsync(int id);
        
    }
}
