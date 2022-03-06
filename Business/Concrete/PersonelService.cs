using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelService : IPersonelService
    {
        private IPersonelDal _personelDal;
        public PersonelService(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IDataResult<Personel> Add(Personel personel)
        {
            if (personel == null)
                return new ErrorDataResult<Personel>("Personel oluşturulamadı!");

            var result = _personelDal.Add(personel);
            if (result == null)
                return new ErrorDataResult<Personel>("Personel oluşturulamadı!");

            return new SuccessDataResult<Personel>(personel);
        }

        public IResult Delete(Personel personel)
        {
            try
            {
                _personelDal.Delete(personel);
                return new SuccessResult("Kullanıcı silindi.");
            }
            catch
            {
                return new ErrorResult("Kullanıcı silinemedi!");
            }
        }

        public IDataResult<Personel> GetById(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
                return new ErrorDataResult<Personel>("Personel bilgisine erişilemedi!");

            var result = _personelDal.Get(x => x.no == id);
            if (result == null)
                return new ErrorDataResult<Personel>("Personel bilgisine erişilemedi!");

            return new SuccessDataResult<Personel>(result);
        }

        public IDataResult<List<Personel>> GetList(string adSoyad, int cinsiyet, int durum)
        {
            var result = _personelDal.GetList().ToList();
            if (adSoyad != null)
            {
                result = result.Where(x => x.adi.ToLower().Contains(adSoyad.ToLower()) || x.soyadi.ToLower().Contains(adSoyad.ToLower())).ToList();
            }
            if(cinsiyet != -1)
            {
                result = result.Where(x => x.cinsiyet == Convert.ToBoolean(cinsiyet)).ToList();
            }
            if (durum != -1)
            {
                result = result.Where(x => x.durum == Convert.ToBoolean(durum)).ToList();
            }
            return new SuccessDataResult<List<Personel>>(result);
        }

        public IResult Update(Personel personel)
        {
            if (personel == null)
                return new ErrorResult("Personel güncellenemedi!");

            var result = _personelDal.Update(personel);
            if (result == null)
                return new ErrorResult("Personel güncellenemedi!");

            return new SuccessResult("Personel başarıyla güncellendi.");
        }
    }
}
