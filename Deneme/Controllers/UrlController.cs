using Deneme.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deneme.Controllers
{
    public class UrlController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {

            var deger = c.Links.ToList();
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index(Link p)
        {

            Random random = new Random();
            string[] karakter = { "A", "B", "C", "D" };
            int k1, k2, k3, s1, s2, s3;

            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            s1 = random.Next(0, 9);
            s2 = random.Next(0, 9);
            s3 = random.Next(0, 9);

            string kod = s1.ToString() + karakter[k1] + s2.ToString() + karakter[k2] + s3.ToString() + karakter[k3];
            p.ShortUrl = "https://localhost:44380/" + kod;
            p.Code = kod;
            c.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult QRCode()
        {
            return View();

        }
        [HttpPost]
        public ActionResult QRCode(int id)
        {
            var deger = c.Links.Where(x => x.Id == id).Select(s => s.ShortUrl).FirstOrDefault();
            ViewBag.d = deger;

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(deger, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
            
        }



    }
}