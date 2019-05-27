using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarRentRestApi.BLL;
using CarRentRestApi.Models;

namespace CarRentRestApi.WebServices
{
    /// <summary>
    /// Summary description for CalisanlarWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalisanlarWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool EkleCalisan(Calisanlar entity)
        {
            try
            {
                using (CalisanlarBusiness calisanlarBusiness = new CalisanlarBusiness())
                {
                    calisanlarBusiness.Ekle(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool SilCalisan(int calisanId)
        {
            try
            {
                using (CalisanlarBusiness calisanlarBusiness = new CalisanlarBusiness())
                {
                    calisanlarBusiness.DeleteById(calisanId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public List<Calisanlar> ListAllCalisanlar()
        {
            try
            {
                using (CalisanlarBusiness calisanlarBusiness = new CalisanlarBusiness())
                {
                    return calisanlarBusiness.ListAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public Calisanlar SelectCalisanById(int calisanId)
        {
            try
            {
                using (CalisanlarBusiness calisanlarBusiness = new CalisanlarBusiness())
                {
                    return calisanlarBusiness.SelectById(calisanId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
