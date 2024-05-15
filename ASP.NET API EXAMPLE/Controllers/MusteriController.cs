using ASP.NET_API_EXAMPLE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusteriYonetimSistemiAPI.Models;

namespace ASP.NET_API_EXAMPLE.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MusteriController : Controller
    {
        private readonly MusteriDbContext _context;

        public MusteriController(MusteriDbContext context)
        {
            _context = context;
        }

        // GET: Musteris
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusteriBilgileri.ToListAsync());
        }

        private IActionResult View(List<Musteri> musteris)
        {
            throw new NotImplementedException();
        }

        // GET: Musteris/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.MusteriBilgileri
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        private IActionResult View(Musteri musteri)
        {
            throw new NotImplementedException();
        }

        // GET: Musteris/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       

        // POST: Musteris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriId,Ad,Soyad,KullaniciAdi,SirketAdi,DogumTarihi,Cinsiyet,TCKimlikNo,Email,Telefon,Adres,Sehir,PostaKodu,Ulke,Notlar")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        // GET: Musteris/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.MusteriBilgileri.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriId,Ad,Soyad,KullaniciAdi,SirketAdi,DogumTarihi,Cinsiyet,TCKimlikNo,Email,Telefon,Adres,Sehir,PostaKodu,Ulke,Notlar")] Musteri musteri)
        {
            if (id != musteri.MusteriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusteriExists(musteri.MusteriId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        // GET: Musteris/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.MusteriBilgileri
                .FirstOrDefaultAsync(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }
        //
        // POST: Musteris/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteri = await _context.MusteriBilgileri.FindAsync(id);
            if (musteri != null)
            {
                _context.MusteriBilgileri.Remove(musteri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusteriExists(int id)
        {
            return _context.MusteriBilgileri.Any(e => e.MusteriId == id);
        }
        // GET: Musteris/ListByCity/Ankara
        [HttpGet]
        public async Task<IActionResult> ListByCity(string cityName)
        {
            var musteriList = await _context.MusteriBilgileri.Where(m => m.Sehir == cityName).ToListAsync();
            return View(musteriList);
        }

        // GET: Musteris/ListByCountry/Turkey
        [HttpGet]
        public async Task<IActionResult> ListByCountry(string countryName)
        {
            var musteriList = await _context.MusteriBilgileri.Where(m => m.Ulke == countryName).ToListAsync();
            return View(musteriList);
        }

        // GET: Musteris/SearchByName?searchTerm=John
        [HttpGet]
        public async Task<IActionResult> SearchByName(string searchTerm)
        {
            var musteriList = await _context.MusteriBilgileri.Where(m => m.Ad.Contains(searchTerm) || m.Soyad.Contains(searchTerm)).ToListAsync();
            return View(musteriList);
        }

        // GET: Musteris/SortByAge
        [HttpGet]
        public async Task<IActionResult> SortByAge()
        {
            var musteriList = await _context.MusteriBilgileri.OrderBy(m => m.DogumTarihi).ToListAsync();
            return View(musteriList);
        }





    }
}
