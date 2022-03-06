using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        public IDataResult<Personel> GetById(int id);
        public IDataResult<Personel> Add(Personel personel);
        public IResult Update(Personel personel);
        public IDataResult<List<Personel>> GetList(string adSoyad, int cinsiyet, int durum);
        public IResult Delete(Personel personel);
    }
}
