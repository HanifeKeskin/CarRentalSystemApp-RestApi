using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.Models;

namespace CarRentRestApi.DAL.Repositories.Abstractions
{
    public interface IRepositoryBase<T>
    {
        List<T> Listele();
        bool Ekle(T entity);
        bool Guncelle(T entity);
        bool Sil(T entity);
        T GetById(int id);
        T DeleteById(int id);
    }
}
