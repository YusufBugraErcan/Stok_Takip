using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stoktakip.Models
{
    public class kesim
    {
        [Key]
        public int UretimNo { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public int EbatBilgisi { get; set; }
        public int ?PaketSayisi { get; set; }
        public string ?SevkiyatSekli { get; set; }
        public string ?kesimUsta { get; set; }
        public string ?FaturaCinsi { get; set; }

        public virtual orders Order { get; set; }
    }
}
