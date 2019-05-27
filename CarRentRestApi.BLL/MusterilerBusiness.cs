using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using CarRentRestApi.DAL;
using System.Security.Authentication;
using CarRentRestApi.DAL.Repositories;

namespace CarRentRestApi.BLL
{
    public class MusterilerBusiness  : IDisposable
    {
        public bool MusteriDogrulama(string username, string pass)
        {
            try
            {
                using (var context = new CarRentalAppContext())
                {
                    bool isUserValid;
                    var result = context.Musteriler.FirstOrDefault(x => x.KullaniciAdi == username && x.Sifre == pass);
                    if (result == null)
                    {
                        isUserValid = false;
                    }
                    else
                    {
                        isUserValid = true;
                    }
                    if (isUserValid)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BusinessLogic:KullaniciBusiness::InsertKullanici::Error occured.", ex);
            }
        }

        private static CarRentalAppContext _context;

        public static CarRentalAppContext Context
        {
            get
            {//context'in her koşulda dolu gelmesi sağlandı
                if (_context == null)
                    _context = new CarRentalAppContext();
                return _context;
            }
            set { _context = value; }
        }

        public bool Ekle(Musteriler entity)
        {
            try
            {
                Context.Set<Musteriler>().Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }
        public Musteriler SelectById(int id)
        {
            return Context.Set<Musteriler>().Find(id);
        }

        public bool DeleteById(int id)
        {
            try
            {
                Context.Set<Musteriler>().Remove(SelectById(id));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }

        public List<Musteriler> ListAll()
        {
            return Context.Set<Musteriler>().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
