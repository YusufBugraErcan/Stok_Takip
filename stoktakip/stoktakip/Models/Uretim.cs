using System.ComponentModel.DataAnnotations;

namespace stoktakip.Models
{
    public class Uretim
    {
        [Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public DateTime UretimBaslangicTarihi { get; set; }
        public DateTime UretimBitisTarihi { get; set; }
        
        
    }
}
