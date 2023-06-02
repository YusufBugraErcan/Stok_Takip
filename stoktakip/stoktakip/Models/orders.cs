using System.ComponentModel.DataAnnotations;

namespace stoktakip.Models
{
    public class orders
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public int LotNo { get; set; }
        public string FirmName { get; set; }
        public string JobName { get; set; }
        public string Notes { get; set; }

    }
}
