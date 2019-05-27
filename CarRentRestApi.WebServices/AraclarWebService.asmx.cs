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
    /// Summary description for AraclarWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AraclarWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool EkleArac(Araclar entity)
        {
            try
            {
                using (AraclarBusiness araclarBusiness = new AraclarBusiness())
                {
                    araclarBusiness.Ekle(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool SilArac(int aracId)
        {
            try
            {
                using (AraclarBusiness araclarBusiness = new AraclarBusiness())
                {
                    araclarBusiness.DeleteById(aracId);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public List<Araclar> ListAllAraclar()
        {
            try
            {
                using (AraclarBusiness araclarBusiness = new AraclarBusiness())
                {
                    return araclarBusiness.ListAll();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public Araclar SelectAracById(int aracId)
        {
            try
            {
                using (AraclarBusiness araclarBusiness = new AraclarBusiness())
                {
                    return araclarBusiness.SelectById(aracId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
