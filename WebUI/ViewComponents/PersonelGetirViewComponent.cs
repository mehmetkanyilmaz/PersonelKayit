using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class PersonelGetirViewComponent : ViewComponent
    {
        private IPersonelService _personelService;
        public PersonelGetirViewComponent(IPersonelService personelService)
        {
            _personelService = personelService;
        }
        public ViewViewComponentResult Invoke(string adSoyad = null, int cinsiyet = -1, int durum = -1)
        {
            var model = _personelService.GetList(adSoyad, cinsiyet, durum).Data.ToList();
            return View(model);
        }
    }
}
