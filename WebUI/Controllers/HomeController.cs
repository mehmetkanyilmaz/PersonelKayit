using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private IPersonelService _personelService;
        public HomeController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Personel(int id = 0)
        {
            if (id == 0)
            {
                //yeni kullanıcı ekle
                return View(new PersonelDto() { personel = new Personel() });
            }

            //Kullanıcı varsa kullanıcı bilgisini post eder.
            var result = _personelService.GetById(id);
            return View(new PersonelDto() { personel = result.Data });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Personel(PersonelDto personelDto)
        {
            //Model doğrulama yapılmadıysa.
            if (!ModelState.IsValid)
            {
                return View(personelDto);
            }

            //ekle
            if (personelDto.personel.no == 0)
            {
                //resim varsa ekler.
                if (personelDto.resim != null && personelDto.resim.FileName.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        personelDto.resim.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string base64Code = Convert.ToBase64String(fileBytes);
                        personelDto.personel.resim_base64 = base64Code;
                    }
                }

                var result = _personelService.Add(personelDto.personel);
                //Personel eklendiyse personel listesine git.
                if (result.Success)
                {
                    return RedirectToAction("PersonelListesi", "Home");
                }
                ViewBag.mesaj = result.Message;
            }
            //güncelle
            else
            {
                //resim varsa günceller.
                if (personelDto.resim != null && personelDto.resim.FileName.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        personelDto.resim.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string base64Code = Convert.ToBase64String(fileBytes);
                        personelDto.personel.resim_base64 = base64Code;
                    }
                }

                var result = _personelService.Update(personelDto.personel);
                //Personel eklendiyse personel listesine git.
                if (result.Success)
                {
                    return RedirectToAction("PersonelListesi", "Home");
                }
                ViewBag.mesaj = result.Message;

            }
            //Personel eklenemediyse yada güncellenemediyse personel detay sayfasına geri döner
            return View(personelDto);
        }

        public IActionResult PersonelListesi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelListesi(string adSoyad, int cinsiyet, int durum)
        {
            return ViewComponent("PersonelGetir", new { adSoyad = adSoyad, cinsiyet = cinsiyet, durum = durum });
        }

        [HttpPost]
        public IResult PersonelSil(int id)
        {
            var personelResult = _personelService.GetById(id);
            if (personelResult.Success == false)
                return new ErrorResult("Personel bilgisine ulaşılamadı.");

            var deletePersonel = _personelService.Delete(personelResult.Data);
            return new Result(deletePersonel.Success, deletePersonel.Message);
        }
    }
}
