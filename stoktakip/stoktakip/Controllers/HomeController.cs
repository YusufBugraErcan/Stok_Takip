using stoktakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using stoktakip.data;
using System.Numerics;
using Microsoft.AspNetCore.Authentication;

namespace stoktakip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly stoktakipDBContext db;
        public HomeController(ILogger<HomeController> logger, stoktakipDBContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            if (db.Database.CanConnect())
            {
                Console.WriteLine("OK");
            }
            var us = db.users.ToList();

            return View();
        }

        [Route("withrole/{id?}")]
        public IActionResult WithRole(int id)
        {
            if (id > 0)
            {
                var list = db.users.Where(m => m.ID == id).Join(db.roles, m => m.roleId, n => n.ID, (user, role) => new { User = user, Role = role })
                   .Select(m => new withRoleDTO()
                   {
                       ID = m.User.ID,
                       username = m.User.username,
                       userpass = m.User.userpass,
                       name = m.User.name,
                       surname = m.User.surname,
                       usermail = m.User.usermail,
                       role = m.Role.userrole
                   })
                   .ToList();

                return View(list);
            }
            else
            {
                var list = db.users.Join(db.roles, m => m.roleId, n => n.ID, (user, role) => new { User = user, Role = role })
                      .Select(m => new withRoleDTO()
                      {
                          ID = m.User.ID,
                          username = m.User.username,
                          userpass = m.User.userpass,
                          name = m.User.name,
                          surname = m.User.surname,
                          usermail = m.User.usermail,
                          role = m.Role.userrole
                      })
                      .ToList();

                return View(list);
            }

        }

        [Route("/Home/create")]
        public IActionResult CreateUser()
        {
            var roles = db.roles.ToList();

            return View(roles);

        }
        [Route("/Home/Create")]
        [HttpPost]
        public IActionResult Create(users user)
        {

            db.users.Add(user);
            db.SaveChanges();
            return RedirectToAction("withrole");

        }

        [Route("/edituser/{id?}")]
        public IActionResult EditUser(int id)
        {

            var user = db.users.Where(m => m.ID == id).FirstOrDefault();

            return View(user);

        }

        [Route("/Home/edit")]
        [HttpPost]
        public IActionResult Edit(users user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("withrole");
        }

        [Route("/home/delete/{id?}")]
        public IActionResult DeleteUser(int id)
        {
            users delete_user = db.users.Where(m => m.ID == id).FirstOrDefault();
            db.Remove(delete_user);
            db.SaveChanges();
            return RedirectToAction("withrole");

        }

        [Route("/Home/createorder")]
        public IActionResult CreateOrder()
        {
            var orders = db.orders.ToList();
            return View(orders);

        }

        [Route("/Home/Createorder")]
        [HttpPost]
        public IActionResult createOrder(orders order, bodinoz bodinoz, matbaa matbaa, kesim kesim)
        {

            db.orders.Add(order);
            db.SaveChanges();
            var newBodinoz = new bodinoz
            {
                OrderID = order.OrderID,
                MalzemeCinsi = bodinoz.MalzemeCinsi,
                SiparisMiktari = bodinoz.SiparisMiktari,
                En = bodinoz.En,
                Kalinlik = bodinoz.Kalinlik,
                KorukBilgisi = bodinoz.KorukBilgisi,
                KoronaBilgisi = bodinoz.KoronaBilgisi,
                RenkBilgisi = bodinoz.RenkBilgisi
            };
            db.bodinoz.Add(newBodinoz);
            db.SaveChanges();

            // Matbaa kaydı
            var newMatbaa = new matbaa
            {
                OrderID = order.OrderID,
                KazanBilgisi = matbaa.KazanBilgisi,
                BaskiRenkleriBilgisi = matbaa.BaskiRenkleriBilgisi,                
                Ebat = (matbaa.Ebat != 0) ? matbaa.Ebat : (int?)null,

                Kilo = (matbaa.Kilo != 0) ? matbaa.Kilo : (int?)null,
                Metre = (matbaa.Metre!=0)?matbaa.Metre:(int?)null,
                Rulo = (matbaa.Rulo!=0)?matbaa.Rulo:(int?)null,
                matbaaUsta = string.IsNullOrEmpty(matbaa.matbaaUsta) ? null : matbaa.matbaaUsta
            };
            db.matbaa.Add(newMatbaa);
            db.SaveChanges();

            // Kesim kaydı
            var newKesim = new kesim
            {
                OrderID = order.OrderID,
                EbatBilgisi = kesim.EbatBilgisi,
                PaketSayisi = (kesim.PaketSayisi != 0) ? kesim.PaketSayisi :(int?)null,
                SevkiyatSekli = string.IsNullOrEmpty(kesim.SevkiyatSekli) ? null:  kesim.SevkiyatSekli,
                kesimUsta = string.IsNullOrEmpty(kesim.kesimUsta) ? null : kesim.kesimUsta,
                FaturaCinsi = string.IsNullOrEmpty(kesim.FaturaCinsi) ? null : kesim.FaturaCinsi,

            };
            db.kesim.Add(newKesim);
            db.SaveChanges();
            return RedirectToAction("ViewOrder");

        }

        string role = "admin";

        [Route("Home/ViewOrder/{id?}")]
        public IActionResult withOrderDetails(int id)
        {
            
            if (id == 0)
            {
                var orderDetails = db.orders
     .Join(db.bodinoz, order => order.OrderID, bodinoz => bodinoz.OrderID, (order, bodinoz) => new { order, bodinoz })
     .Join(db.matbaa, temp => temp.order.OrderID, matbaa => matbaa.OrderID, (temp, matbaa) => new { temp.order, temp.bodinoz, matbaa })
     .Join(db.kesim, temp => temp.order.OrderID, kesim => kesim.OrderID, (temp, kesim) => new withOrderDTO
     {
         OrderID = temp.order.OrderID,
         OrderDate = temp.order.OrderDate,
         DeliverDate = temp.order.DeliverDate,
         LotNo = temp.order.LotNo,
         FirmName = temp.order.FirmName,
         JobName = temp.order.JobName,
         Notes = temp.order.Notes,
         KazanBilgisi = temp.matbaa.KazanBilgisi,
         BaskiRenkleriBilgisi = temp.matbaa.BaskiRenkleriBilgisi,
         Ebat = temp.matbaa.Ebat.HasValue ? temp.matbaa.Ebat.Value : 0,
         Kilo = temp.matbaa.Kilo.HasValue ? temp.matbaa.Kilo.Value : 0,
         Metre = temp.matbaa.Metre.HasValue ? temp.matbaa.Metre.Value : 0,
         Rulo = temp.matbaa.Rulo.HasValue ? temp.matbaa.Rulo.Value : 0,
         matbaaUsta = temp.matbaa.matbaaUsta,
         EbatBilgisi = kesim.EbatBilgisi,
         PaketSayisi = kesim.PaketSayisi.HasValue ? kesim.PaketSayisi.Value: 0,
         SevkiyatSekli = kesim.SevkiyatSekli,
         FaturaCinsi = kesim.FaturaCinsi,
         kesimUsta = kesim.kesimUsta,
         MalzemeCinsi = temp.bodinoz.MalzemeCinsi,
         SiparisMiktari = temp.bodinoz.SiparisMiktari,
         En = temp.bodinoz.En,
         Kalinlik = temp.bodinoz.Kalinlik,
         KorukBilgisi = temp.bodinoz.KorukBilgisi,
         KoronaBilgisi = temp.bodinoz.KoronaBilgisi,
         RenkBilgisi = temp.bodinoz.RenkBilgisi
         

     })

.ToList();
                return View(orderDetails);
            }
            else
            {
                var orderDetails = db.orders
     .Join(db.bodinoz, order => order.OrderID, bodinoz => bodinoz.OrderID, (order, bodinoz) => new { order, bodinoz })
     .Join(db.matbaa, temp => temp.order.OrderID, matbaa => matbaa.OrderID, (temp, matbaa) => new { temp.order, temp.bodinoz, matbaa })
     .Join(db.kesim, temp => temp.order.OrderID, kesim => kesim.OrderID, (temp, kesim) => new withOrderDTO
     {
         OrderID = temp.order.OrderID,
         OrderDate = temp.order.OrderDate,
         DeliverDate = temp.order.DeliverDate,
         LotNo = temp.order.LotNo,
         FirmName = temp.order.FirmName,
         JobName = temp.order.JobName,
         Notes = temp.order.Notes,
         KazanBilgisi = temp.matbaa.KazanBilgisi,
         BaskiRenkleriBilgisi = temp.matbaa.BaskiRenkleriBilgisi,
         Ebat = temp.matbaa.Ebat ?? 0,
         Kilo = temp.matbaa.Kilo ?? 0,
         Metre = temp.matbaa.Metre ?? 0,
         Rulo = temp.matbaa.Rulo ?? 0,
         matbaaUsta = temp.matbaa.matbaaUsta,
         EbatBilgisi = kesim.EbatBilgisi,
         PaketSayisi = kesim.PaketSayisi.HasValue ? kesim.PaketSayisi.Value:0,
         SevkiyatSekli = kesim.SevkiyatSekli,
         FaturaCinsi = kesim.FaturaCinsi,
         kesimUsta = kesim.kesimUsta,
         MalzemeCinsi = temp.bodinoz.MalzemeCinsi,
         SiparisMiktari = temp.bodinoz.SiparisMiktari,
         En = temp.bodinoz.En,
         Kalinlik = temp.bodinoz.Kalinlik,
         KorukBilgisi = temp.bodinoz.KorukBilgisi,
         KoronaBilgisi = temp.bodinoz.KoronaBilgisi,
         RenkBilgisi = temp.bodinoz.RenkBilgisi
     })
     .Where(order => order.OrderID == id)
     .ToList();
                return View(orderDetails);
            }





        }
        [Route("/home/deleteorder/{orderId?}")]
        public IActionResult DeleteOrder(int orderId)
        {
            Uretim deleteUretim = db.Uretim.FirstOrDefault(m => m.OrderID == orderId);

            if (deleteUretim != null)
            {
                db.Uretim.Remove(deleteUretim);
                db.SaveChanges();
            }
            else
            {
                

            }

            bodinoz deleteBodinoz = db.bodinoz.FirstOrDefault(m => m.OrderID == orderId);
            if (deleteBodinoz != null)
            {
                db.bodinoz.Remove(deleteBodinoz);
            }

            matbaa deleteMatbaa = db.matbaa.FirstOrDefault(m => m.OrderID == orderId);
            if (deleteMatbaa != null)
            {
                db.matbaa.Remove(deleteMatbaa);
            }

            kesim deleteKesim = db.kesim.FirstOrDefault(m => m.OrderID == orderId);
            if (deleteKesim != null)
            {
                db.kesim.Remove(deleteKesim);
            }

            orders deleteOrder = db.orders.FirstOrDefault(m => m.OrderID == orderId);
            if (deleteOrder != null)
            {
                db.orders.Remove(deleteOrder);
            }

            db.SaveChanges();


            return RedirectToAction("ViewOrder");
        }


        [Route("/editorder/{id?}")]
        public IActionResult EditOrder(int id)
        {

            var orderDetails = db.orders
             .Join(db.bodinoz, order => order.OrderID, bodinoz => bodinoz.OrderID, (order, bodinoz) => new { order, bodinoz })
             .Join(db.matbaa, temp => temp.order.OrderID, matbaa => matbaa.OrderID, (temp, matbaa) => new { temp.order, temp.bodinoz, matbaa })
             .Join(db.kesim, temp => temp.order.OrderID, kesim => kesim.OrderID, (temp, kesim) => new withOrderDTO
             {
                 OrderID = temp.order.OrderID,
                 OrderDate = temp.order.OrderDate,
                 DeliverDate = temp.order.DeliverDate,
                 LotNo = temp.order.LotNo,
                 FirmName = temp.order.FirmName,
                 JobName = temp.order.JobName,
                 Notes = temp.order.Notes,
                 KazanBilgisi = temp.matbaa.KazanBilgisi,
                 BaskiRenkleriBilgisi = temp.matbaa.BaskiRenkleriBilgisi,
                 Ebat = temp.matbaa.Ebat ?? 0,
                 Kilo = temp.matbaa.Kilo ?? 0,
                 Metre = temp.matbaa.Metre ?? 0,
                 Rulo = temp.matbaa.Rulo ?? 0,
                 matbaaUsta = temp.matbaa.matbaaUsta,
                 EbatBilgisi = kesim.EbatBilgisi,
                 PaketSayisi = kesim.PaketSayisi.HasValue ? kesim.PaketSayisi.Value:0,
                 SevkiyatSekli = kesim.SevkiyatSekli,
                 FaturaCinsi = kesim.FaturaCinsi,
                 kesimUsta = kesim.kesimUsta,
                 MalzemeCinsi = temp.bodinoz.MalzemeCinsi,
                 SiparisMiktari = temp.bodinoz.SiparisMiktari,
                 En = temp.bodinoz.En,
                 Kalinlik = temp.bodinoz.Kalinlik,
                 KorukBilgisi = temp.bodinoz.KorukBilgisi,
                 KoronaBilgisi = temp.bodinoz.KoronaBilgisi,
                 RenkBilgisi = temp.bodinoz.RenkBilgisi
             })
             .Where(order => order.OrderID == id)
             .FirstOrDefault();
            return View(orderDetails);



        }

        [Route("/Home/Editorder")]
        [HttpPost]
        public IActionResult Edito(withOrderDTO order)
        {
            //Order ID'ye göre bodinoz kayıtları
            bodinoz b = db.bodinoz.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
            b.MalzemeCinsi = order.MalzemeCinsi;
            b.SiparisMiktari = order.SiparisMiktari;
            b.KorukBilgisi = order.KorukBilgisi;
            b.RenkBilgisi = order.RenkBilgisi;
            b.KoronaBilgisi = order.KoronaBilgisi;
            b.Kalinlik = order.Kalinlik;
            b.En = order.En;

            matbaa m = db.matbaa.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
            m.KazanBilgisi = order.KazanBilgisi;
            m.BaskiRenkleriBilgisi = order.BaskiRenkleriBilgisi;
            m.Ebat = order.Ebat;
            m.Kilo = order.Kilo;
            m.Metre = order.Metre;
            m.Rulo = order.Rulo;
            m.matbaaUsta = order.matbaaUsta;

            kesim k = db.kesim.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
            k.EbatBilgisi = order.EbatBilgisi;
            k.PaketSayisi = order.PaketSayisi;
            k.SevkiyatSekli = order.SevkiyatSekli;
            k.kesimUsta = order.kesimUsta;
            k.FaturaCinsi = order.FaturaCinsi;

            orders o = db.orders.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
            o.OrderDate = order.OrderDate;
            o.DeliverDate = order.DeliverDate;
            o.LotNo = order.LotNo;
            o.FirmName = order.FirmName;
            o.JobName = order.JobName;
            o.Notes = order.Notes;

            db.Entry(b).State = EntityState.Modified;
            db.Entry(m).State = EntityState.Modified;
            db.Entry(k).State = EntityState.Modified;
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("withOrderDetails");
        }


        [Route("/Home/CreateStock")]
        public IActionResult Createstock()
        {
            var model = new Stok();
            return View(model);
        }

        [Route("/Home/CreateStock")]
        [HttpPost]
        public IActionResult CreateStock(Stok model)
        {
            if (ModelState.IsValid)
            {

                db.Stok.Add(model);
                db.SaveChanges();


                return RedirectToAction("StockList");
            }


            return View(model);
        }

        [Route("/Home/StockList")]
        public IActionResult StockList()
        {
            var stoklar = db.Stok.ToList();
            return View(stoklar);
        }

        
        [Route("/Home/DeleteStock/{ID}")]
        public IActionResult DeleteStock(int ID)
        {
            var stok = db.Stok.FirstOrDefault(s => s.ID == ID);
            if (stok != null)
            {
                db.Stok.Remove(stok);
                db.SaveChanges();
            }

            return RedirectToAction("StockList");
        }



        [Route("/Home/EditStock/{id?}")]
        public IActionResult EditStock(int id)
        {
            var stok = db.Stok.FirstOrDefault(s => s.ID == id);
            if (stok == null)
            {
                return RedirectToAction("StockList");
            }

            return View("EditStock", stok);
        }

        [HttpPost]
        [Route("/Home/EditStock/{id}")]
        public IActionResult UpdateStock(int id, Stok model)
        {
            if (ModelState.IsValid)
            {
                var stok = db.Stok.FirstOrDefault(s => s.ID == id);
                if (stok != null)
                {
                    stok.FirmaAdı = model.FirmaAdı;
                    stok.UrunCinsi = model.UrunCinsi;
                    stok.UrunMiktarı = model.UrunMiktarı;
                    stok.UrunTuru = model.UrunTuru;
                    stok.tarih=model.tarih;

                    db.SaveChanges();
                }

                return RedirectToAction("StockList");
            }

            return View("EditStock", model);
        }


        
        [Route("/Home/Createplan/{id}")]
        public IActionResult Createplan(int id)
        {
            PlanDTO planDTO = new PlanDTO();
            Uretim uretim=db.Uretim.Where(x=> x.OrderID == id).FirstOrDefault();
            
            
            if (uretim == null) 
            {
                uretim = new Uretim();
                uretim.OrderID = id;
                cinsTurDTO? ct = new cinsTurDTO();
                ct.cins = db.Stok.Select(m => m.UrunCinsi).Distinct().ToList();
                ct.tur = new List<string>();
                ct.selectedCins = "";
                ct.selectedTur = "";
                ct.maxAdet = 0;
                                
                planDTO.OrderID =id;
                planDTO.cinstur = ct;
            }
            else
            {
                cinsTurDTO? ct = new cinsTurDTO();
                ct.cins = db.Stok.Select(m => m.UrunCinsi).Distinct().ToList();
                ct.tur = new List<string>();
                ct.selectedCins = "";
                ct.selectedTur = "";
                ct.maxAdet = 0;                
                planDTO.ID = id;
                planDTO.OrderID = uretim.OrderID;
                planDTO.UretimBaslangicTarihi = uretim.UretimBaslangicTarihi;
                planDTO.UretimBitisTarihi = uretim.UretimBitisTarihi;
                planDTO.cinstur = ct;
            }


            return View(planDTO);
        }


        [HttpPost]
        [Route("/Home/createplan")]
        public IActionResult Updateteplan(PlanDTOSend plandto)
        {
            int maxAdet = plandto.maxAdet;
            int adet=plandto.adet;

            if(maxAdet >= adet) 
            {
                
                List<Stok> sts = db.Stok.Where(m => m.UrunCinsi.Equals(plandto.cins[0]) && m.UrunTuru.Equals(plandto.tur[0])).ToList();
                foreach (var item in sts)
                {
                    if (item.UrunMiktarı < adet)
                    {
                        adet -= item.UrunMiktarı;
                        item.UrunMiktarı = 0;
                    }
                    else
                    {
                        
                        item.UrunMiktarı -= adet;
                        adet = 0;
                    }
                }
                db.SaveChanges();
                Uretim uretim = db.Uretim.Where(x => x.OrderID == plandto.OrderID).FirstOrDefault();

                if (uretim != null)
                {
                    
                    uretim.UretimBaslangicTarihi=plandto.UretimBaslangicTarihi;
                    uretim.UretimBitisTarihi=plandto.UretimBitisTarihi;
                    db.Entry(uretim).State = EntityState.Modified;


                }
                else
                {
                    uretim = new Uretim();
                    uretim.OrderID = plandto.OrderID;
                    uretim.UretimBaslangicTarihi = plandto.UretimBaslangicTarihi;
                    uretim.UretimBitisTarihi = plandto.UretimBitisTarihi;
                    db.Uretim.Add(uretim);
                    
                }
                db.SaveChanges();
            }
            

            
            
            

            return RedirectToAction("withOrderDetails");
        }

       

        public ActionResult GetUretim(cinsTurSelected cts)
        {
            cinsTurDTO? ct = null;
            if (cts.cins == null && cts.tur == null)
            {
                ct = new cinsTurDTO();
                ct.cins = db.Stok.Select(m => m.UrunCinsi).Distinct().ToList();
                ct.tur = new List<string>();
                ct.selectedCins = "";
                ct.selectedTur = "";
                ct.maxAdet = 0;
            }
            else if (cts.cins != null && cts.tur == null)
            {
                List<Stok> uretimList = db.Stok.Where(m => m.UrunCinsi.Equals(cts.cins)).ToList();
                ct = new cinsTurDTO();
                ct.cins = db.Stok.Select(m => m.UrunCinsi).Distinct().ToList();
                ct.tur = uretimList.Select(m => m.UrunTuru).Distinct().ToList();
                ct.selectedCins = cts.cins;
                ct.selectedTur = "";
                ct.maxAdet = uretimList.Sum(m => m.UrunMiktarı);
            }
            else
            {
                List<Stok> uretimList = db.Stok.Where(m => m.UrunCinsi.Equals(cts.cins)).ToList();
                ct = new cinsTurDTO();
                ct.cins = db.Stok.Select(m => m.UrunCinsi).Distinct().ToList();
                ct.tur = uretimList.Select(m => m.UrunTuru).Distinct().ToList();
                ct.selectedCins = cts.cins;
                ct.selectedTur = cts.tur;
                ct.maxAdet = db.Stok.Where(m => m.UrunCinsi.Equals(cts.cins) && m.UrunTuru.Equals(cts.tur)).Sum(m => m.UrunMiktarı);
            }
            return PartialView("_uretim", ct);
        }

        
        


















    }
}
