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
    public class AdminService : IAdminService
    {
        private IAdminDal _adminDal;
        public AdminService(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public IDataResult<Admin> Login(Admin admin)
        {
            var result = _adminDal.Get(x => x.kullanici_kodu == admin.kullanici_kodu && x.sifre == admin.sifre);
            if (result == null)
                return new ErrorDataResult<Admin>("Kullancı kodu veya şifre hatalı.");
            return new SuccessDataResult<Admin>(result);
        }
    }
}
