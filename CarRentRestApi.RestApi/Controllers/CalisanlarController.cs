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
    public class CalisanlarController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var calisanlarBusiness = new CalisanlarBusiness())
            {
                // Get customers from business layer (Core App)
                List<Calisanlar> calisanlar = calisanlarBusiness.ListAll();

                // Prepare a content
                var content = new ResponseContent<Calisanlar>(calisanlar);

                // Return content as a json and proper http response
                return new StandartResult<Calisanlar>(content, Request);
            }
        }
        
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Calisanlar> content;

            using (var calisanlarBusiness = new CalisanlarBusiness())
            {
                // Get customer from business layer (Core App)
                List<Calisanlar> calisanlar = null;
                try
                {
                    var c = calisanlarBusiness.SelectById(id);
                    if (c != null)
                    {
                        calisanlar = new List<Calisanlar>();
                        calisanlar.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<Calisanlar>(calisanlar);

                    // Return content as a json and proper http response
                    return new XmlResult<Calisanlar>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<Calisanlar>(null);
                    return new XmlResult<Calisanlar>(content, Request);
                }
            }
        }

        public IHttpActionResult Post([FromBody]Calisanlar calisanlar)
        {
            var content = new ResponseContent<Calisanlar>(null);
            if (calisanlar != null)
            {
                using (var calisanBusiness = new CalisanlarBusiness())
                {
                    content.Result = calisanBusiness.Ekle(calisanlar) ? "1" : "0";

                    return new StandartResult<Calisanlar>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Calisanlar>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Calisanlar>(null);

            using (var calisanBusiness = new CalisanlarBusiness())
            {
                content.Result = calisanBusiness.DeleteById(id) ? "1" : "0";

                return new StandartResult<Calisanlar>(content, Request);
            }
        }

    }
}