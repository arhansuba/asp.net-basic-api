namespace MusteriYonetimSistemiAPI.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public required string Ad { get; set; }
        public required string Soyad { get; set; }
        public required string KullaniciAdi { get; set; }
        
        public required string SirketAdi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public required string Cinsiyet { get; set; }
        public required string TCKimlikNo { get; set; }
        public required string Email { get; set; }
        public required string Telefon { get; set; }
        public required string Adres { get; set; }
        public required string Sehir { get; set; }
        public required string PostaKodu { get; set; }
        public required string Ulke { get; set; }
        public  string? Notlar { get; set; }

      
    }
}
