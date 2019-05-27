using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;
using System.Data.Entity;

namespace CarRentRestApi.DAL
{
    public class CarRentalAppContext : DbContext
    {
        public CarRentalAppContext() : base("CarRentalSystem")
        {

        }
        public DbSet<Araclar> Araclar { get; set; }
        public DbSet<Calisanlar> Calisanlar { get; set; }
        public DbSet<KiralikBilgi> KiralikBilgi { get; set; }
        public DbSet<Musteriler> Musteriler { get; set; }
        public DbSet<Sirket> Sirket { get; set; }
        public DbSet<RezervasyonBilgi> RezervasyonBilgi { get; set; }
    }
}
