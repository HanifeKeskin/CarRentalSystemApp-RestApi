using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using CarRentRestApi.DAL;

namespace CarRentRestApi.BLL
{
    public class SirketBusiness : IDisposable
    {
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

        public bool Ekle(Sirket entity)
        {
            try
            {
                Context.Set<Sirket>().Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }
        public Sirket SelectById(int id)
        {
            return Context.Set<Sirket>().Find(id);
        }

        public bool DeleteById(int id)
        {
            try
            {
                Context.Set<Sirket>().Remove(SelectById(id));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }

        public List<Sirket> ListAll()
        {
            return Context.Set<Sirket>().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
