using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MusteriYonetimSistemiAPI.Models;

namespace MVCProject.Controllers
{
    public class MusteriController : Controller
        {
        private readonly List<Musteri> _musteriListesi =
        [
          
        ];




        public IActionResult Index()
            {
                return View(_musteriListesi);
            }

            
            public IActionResult Details(int id)
            {
                var musteri = _musteriListesi.FirstOrDefault(m => m.MusteriId == id);
                if (musteri == null)
                {
                    return NotFound();
                }
                return View(musteri);
            }
        }

    internal class NewClass(int musteriId, string ad, string soyad, string email)
    {
        public int MusteriId { get; } = musteriId;
        public string Ad { get; } = ad;
        public string Soyad { get; } = soyad;
        public string Email { get; } = email;

        public override bool Equals(object? obj)
        {
            return obj is NewClass other &&
                   MusteriId == other.MusteriId &&
                   Ad == other.Ad &&
                   Soyad == other.Soyad &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MusteriId, Ad, Soyad, Email);
        }
    }
}

    public class MusteriController(ILogger<MusteriController> logger) : Controller
    {
        private readonly ILogger<MusteriController> _logger = logger;

    public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MVCProject.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

