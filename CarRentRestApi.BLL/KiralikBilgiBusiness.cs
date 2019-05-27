using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using CarRentRestApi.DAL;
using CarRentRestApi.DAL.Repositories.Concretes;

namespace CarRentRestApi.BLL
{
    public class KiralikBilgiBusiness : IDisposable
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

        public bool Ekle(KiralikBilgi entity)
        {
            try
            {
                Context.Set<KiralikBilgi>().Add(entity);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracEkle::Error occured.", ex);
            }
        }
        public KiralikBilgi SelectById(int id)
        {
            return Context.Set<KiralikBilgi>().Find(id);
        }

        public bool DeleteById(int id)
        {
            try
            {
                Context.Set<KiralikBilgi>().Remove(SelectById(id));
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Business:AraclarBusiness::AracSil::Error occured.", ex);
            }
        }

        public List<KiralikBilgi> ListAll()
        {
            return Context.Set<KiralikBilgi>().ToList();
           
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
