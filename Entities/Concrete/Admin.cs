using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Kullanıcı kodu zorunludur.")]
        [DisplayName("Kullanıcı Kodu")]
        [MinLength(3,ErrorMessage = "En az 3 karakter olmalıdır")]
        public string kullanici_kodu { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DisplayName("Şifre")]
        [MinLength(6, ErrorMessage = "En az 6 karakter olmalıdır")]
        public string sifre { get; set; }
    }
}
