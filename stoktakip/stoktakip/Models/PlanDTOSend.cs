namespace stoktakip.Models
{
    public class PlanDTOSend
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public DateTime UretimBaslangicTarihi { get; set; }
        public DateTime UretimBitisTarihi { get; set; }
        public List<string> cins { get; set; }
        public List<string> tur { get; set; }
        public string selectedCins { get; set; }
        public string selectedTur { get; set; }
        public int maxAdet { get; set; }
        public int adet { get; set; }
    }
}
