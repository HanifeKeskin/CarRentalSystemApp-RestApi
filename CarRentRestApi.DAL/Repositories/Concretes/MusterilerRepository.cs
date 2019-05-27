using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using CarRentRestApi.DAL.Repositories.Abstractions;
using System.Security.Authentication;

namespace CarRentRestApi.DAL.Repositories.Concretes
{
    public class MusterilerRepository : RepositoryBase<Musteriler> , IMusterilerRepository
    {
        public Musteriler idAl(string username)
        {
            using (var context = new CarRentalAppContext())
            {
                // context.Database.Connection.Open();
                var result = context.Musteriler.FirstOrDefault(x => x.KullaniciAdi == username);

                if (result == null)
                {
                    throw new AuthenticationException("Kullanıcı Girişi Başarısız !");
                }
                return result;
            }
        }

        public bool sifreKontrol(string username, string pass)
        {
            using (var context = new CarRentalAppContext())
            {
                var isUserValid = context.Musteriler.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == pass);
                if (isUserValid != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
