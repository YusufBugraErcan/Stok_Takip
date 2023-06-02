using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stoktakip.Models
{
    public class bodinoz
    {
        [Key]
        public int UretimNo { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public string MalzemeCinsi { get; set; }
        public int SiparisMiktari { get; set; }
        public int En { get; set; }
        public int Kalinlik { get; set; }
        public string KorukBilgisi { get; set; }
        public string KoronaBilgisi { get; set; }
        public string RenkBilgisi { get; set; }
        public virtual orders Order { get; set; }
    }
}