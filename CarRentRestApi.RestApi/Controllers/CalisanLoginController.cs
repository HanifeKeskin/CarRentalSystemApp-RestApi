using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentRestApi.BLL;
using CarRentRestApi.Models;
using CarRentRestApi.RestApi.Models;
using CarRentRestApi.RestApi.Results;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CarRentRestApi.RestApi.Controllers
{
    public class CalisanLoginController :ApiController
    {
        public IHttpActionResult Get(string kullaniciAdi, string pass)
        {
            using (var calisanlarBusiness = new CalisanlarBusiness())
            {
                bool dogruMu = calisanlarBusiness.CalisanDogrulama(kullaniciAdi, pass);
                SifreKontrol kontrol = new SifreKontrol { isValid = dogruMu };
                List<SifreKontrol> sifreKontrol = new List<SifreKontrol>();
                sifreKontrol.Add(kontrol);

                var content = new ResponseContent<SifreKontrol>(sifreKontrol);

                // Return content as a json and proper http response
                return new StandartResult<SifreKontrol>(content, Request);

            }
        }
    }
}