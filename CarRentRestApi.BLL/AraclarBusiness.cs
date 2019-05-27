using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using CarRentRestApi.DAL;

namespace CarRentRestApi.BLL
{
    public class AraclarBusiness : IDisposable
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

        public bool Ekle(Araclar entity)
        {
            try
            {
                Context.Set<Araclar>().Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }

        public Araclar SelectById(int id)
        {
            return Context.Set<Araclar>().Find(id);
        }

        public bool DeleteById(int id)
        {
            try
            {
                Context.Set<Araclar>().Remove(SelectById(id));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracSil::Error occured.", ex);
            }
        }

        public List<Araclar> ListAll()
        {
            return Context.Set<Araclar>().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
