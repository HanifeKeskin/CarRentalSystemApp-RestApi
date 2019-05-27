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
    /// Summary description for KiralikBilgiWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KiralikBilgiWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool EkleKiralama(KiralikBilgi entity)
        {
            try
            {
                using (KiralikBilgiBusiness kiralikBilgiBusiness = new KiralikBilgiBusiness())
                {
                    kiralikBilgiBusiness.Ekle(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool SilKiralikBilgi(int kiralikBilgiId)
        {
            try
            {
                using (KiralikBilgiBusiness kiralikBilgiBusiness = new KiralikBilgiBusiness())
                {
                    kiralikBilgiBusiness.DeleteById(kiralikBilgiId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public List<KiralikBilgi> ListAllKiralikBilgiler()
        {
            try
            {
                using (KiralikBilgiBusiness kiralikBilgiBusiness = new KiralikBilgiBusiness())
                {
                    return kiralikBilgiBusiness.ListAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public KiralikBilgi SelectKiralikBilgiById(int kiralikBilgiId)
        {
            try
            {
                using (KiralikBilgiBusiness kiralikBilgiBusiness = new KiralikBilgiBusiness())
                {
                    return kiralikBilgiBusiness.SelectById(kiralikBilgiId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
