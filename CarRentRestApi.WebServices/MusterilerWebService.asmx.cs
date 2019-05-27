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
    /// Summary description for MusterilerWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MusterilerWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool EkleMusteri(Musteriler entity)
        {
            try
            {
                using (MusterilerBusiness musterilerBusiness = new MusterilerBusiness())
                {
                    musterilerBusiness.Ekle(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool SilMusteri(int musteriId)
        {
            try
            {
                using (MusterilerBusiness musterilerBusiness = new MusterilerBusiness())
                {
                    musterilerBusiness.DeleteById(musteriId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public List<Musteriler> ListAllMusteriler()
        {
            try
            {
                using (MusterilerBusiness musterilerBusiness = new MusterilerBusiness())
                {
                    return musterilerBusiness.ListAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public Musteriler SelectMusteriById(int musteriId)
        {
            try
            {
                using (MusterilerBusiness musterilerBusiness = new MusterilerBusiness())
                {
                    return musterilerBusiness.SelectById(musteriId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
