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
    public class AraclarController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var araclarBusiness = new AraclarBusiness())
            {
                // Get customers from business layer (Core App)
                List<Araclar> araclar = araclarBusiness.ListAll();

                // Prepare a content
                var content = new ResponseContent<Araclar>(araclar);

                // Return content as a json and proper http response
                return new StandartResult<Araclar>(content, Request);
            }
        }

        public IHttpActionResult Get(int id)
        {
            ResponseContent<Araclar> content;

            using (var araclarBusiness = new AraclarBusiness())
            {
                // Get customer from business layer (Core App)
                List<Araclar> araclar = null;
                try
                {
                    var c = araclarBusiness.SelectById(id);
                    if (c != null)
                    {
                        araclar = new List<Araclar>();
                        araclar.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<Araclar>(araclar);

                    // Return content as a json and proper http response
                    return new XmlResult<Araclar>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<Araclar>(null);
                    return new XmlResult<Araclar>(content, Request);
                }
            }
        }

        public IHttpActionResult Post([FromBody]Araclar araclar)
        {
            var content = new ResponseContent<Araclar>(null);
            if (araclar != null)
            {
                using (var araclarBusiness = new AraclarBusiness())
                {
                    content.Result = araclarBusiness.Ekle(araclar) ? "1" : "0";

                    return new StandartResult<Araclar>(content, Request);
                }
            }
            else {
                content.Result = "0";

                return new StandartResult<Araclar>(content, Request);
            }
            
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Araclar>(null);

            using (var araclarBusiness = new AraclarBusiness())
            {
                content.Result = araclarBusiness.DeleteById(id) ? "1" : "0";

                return new StandartResult<Araclar>(content, Request);
            }
        }
    }
}