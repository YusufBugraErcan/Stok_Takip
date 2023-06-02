using System.ComponentModel.DataAnnotations;

namespace stoktakip.Models
{
    public class Stok
    {
        [Key]
        public int ID { get; set; }
        public string FirmaAdı { get; set; }
        public string UrunCinsi { get; set;}

        public int UrunMiktarı { get; set;}
        public string UrunTuru { get; set;}

        public DateTime tarih { get; set; }

        
    }
}
