using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PersonelDto : IDto
    {
        public Personel personel { get; set; }
        public IFormFile resim { get; set; }
    }
}
