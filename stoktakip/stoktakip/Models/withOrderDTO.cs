namespace stoktakip.Models
{
    public class withOrderDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }

        public int LotNo { get; set; }
        public string FirmName { get; set; }
        public string JobName { get; set; } 
        public string Notes { get; set; }

        public string KazanBilgisi { get; set; }

        public string BaskiRenkleriBilgisi { get; set; }

        public int Ebat { get; set; }

        public int Kilo { get; set; }
        public int Metre { get; set; }
        public int Rulo { get; set; }
        public string matbaaUsta { get; set; }
        public int EbatBilgisi { get; set; }
        public int PaketSayisi { get; set; }
        public string SevkiyatSekli { get; set; }
        
        public string FaturaCinsi { get; set; }

        public string MalzemeCinsi { get; set; }
        public int SiparisMiktari { get; set; }
        public int En { get; set; }
        public int Kalinlik { get; set; }
        public string KorukBilgisi { get; set; }
        public string KoronaBilgisi { get; set; }
        public string RenkBilgisi { get; set; }

        public string kesimUsta { get; set; }

        public DateTime UretimBaslangicTarihi { get; set; }
        public DateTime UretimBitisTarihi { get; set; }
    }
}
