using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace stoktakip.Models
{
    public class matbaa
    {
        [Key]
        public int UretimNo { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public string KazanBilgisi { get; set; }
        
        public string BaskiRenkleriBilgisi { get; set; }
        
        public int ?Ebat { get; set; }

        public int? Kilo { get; set; }
        public int ?Metre { get; set; }
        public int ?Rulo { get; set; }
        public string ?matbaaUsta { get; set; }
        public virtual orders Order { get; set; }
    }
}
