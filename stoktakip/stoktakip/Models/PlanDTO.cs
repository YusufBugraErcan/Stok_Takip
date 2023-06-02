namespace stoktakip.Models
{
    public class PlanDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public DateTime UretimBaslangicTarihi { get; set; }
        public DateTime UretimBitisTarihi { get; set; }

        public cinsTurDTO cinstur { get; set; }


    }
}
