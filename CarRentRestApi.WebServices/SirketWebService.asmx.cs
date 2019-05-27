using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarRentRestApi.Models;
using CarRentRestApi.BLL;

namespace CarRentRestApi.WebServices
{
    /// <summary>
    /// Summary description for SirketWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SirketWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool EkleSirket(Sirket entity)
        {
            try
            {
                using (SirketBusiness sirketBusiness = new SirketBusiness())
                {
                    sirketBusiness.Ekle(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool SilSirket(int sirketId)
        {
            try
            {
                using (SirketBusiness sirketBusiness = new SirketBusiness())
                {
                    sirketBusiness.DeleteById(sirketId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public List<Sirket> ListAllSirketler()
        {
            try
            {
                using (SirketBusiness sirketBusiness = new SirketBusiness())
                {
                    return sirketBusiness.ListAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public Sirket SelectSirketById(int sirketId)
        {
            try
            {
                using (SirketBusiness sirketBusiness = new SirketBusiness())
                {
                    return sirketBusiness.SelectById(sirketId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
