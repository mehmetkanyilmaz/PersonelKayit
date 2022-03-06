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
    public class Personel : IEntity
    {
        [Key]
        [Required]
        public int no { get; set; }

        [Required(ErrorMessage = "TC no zorunludur.")]
        [DisplayName("TC No")]
        [MinLength(11, ErrorMessage = "Tc no 11 karakter olmalıdır")]
        [MaxLength(11, ErrorMessage = "Tc no 11 karakter olmalıdır")]
        public string tc_no { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [DisplayName("Ad")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        public string adi { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [DisplayName("Soyad")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        public string soyadi { get; set; }

        [Required(ErrorMessage = "Telefon no zorunludur.")]
        [DisplayName("Telefon No")]
        [MinLength(11, ErrorMessage = "Telefon no 11 karakter olmalıdır")]
        [MaxLength(11, ErrorMessage = "Telefon no 11 karakter olmalıdır")]
        [Phone]
        public string telefon_no { get; set; }

        [Required(ErrorMessage = "Cinsiyet bilgisi zorunludur.")]
        [DisplayName("Cinsiyet")]
        public bool cinsiyet { get; set; }

        [Required(ErrorMessage = "Şehir zorunludur.")]
        [DisplayName("Şehir")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        public string sehir { get; set; }

        [Required(ErrorMessage = "Adres zorunludur.")]
        [DisplayName("Adres")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        public string adres { get; set; }

        [Required(ErrorMessage = "Doğum yeri zorunludur.")]
        [DisplayName("Doğum Yeri")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır")]
        public string dogum_yeri { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        [DisplayName("Doğum Tarihi")]
        public DateTime dogum_tarihi { get; set; }

        [DisplayName("Personel Resmi")]
        public string resim_base64 { get; set; }

        [Required(ErrorMessage = "Yaka bilgisi zorunludur.")]
        [DisplayName("Yaka Bilgisi")]
        public bool yaka { get; set; }

        [Required(ErrorMessage = "Durum bilgisi zorunludur.")]
        [DisplayName("Durum")]
        public bool durum { get; set; }
    }
}
