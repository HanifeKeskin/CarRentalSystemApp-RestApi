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
    public class KiralikBilgiController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var kiralikBilgiBusiness = new KiralikBilgiBusiness())
            {
                // Get customers from business layer (Core App)
                List<KiralikBilgi> kiralikbilgiler = kiralikBilgiBusiness.ListAll();

                // Prepare a content
                var content = new ResponseContent<KiralikBilgi>(kiralikbilgiler);

                // Return content as a json and proper http response
                return new StandartResult<KiralikBilgi>(content, Request);
            }
        }

        public IHttpActionResult Get(int id)
        {
            ResponseContent<KiralikBilgi> content;

            using (var kiralikBilgiBusiness = new KiralikBilgiBusiness())
            {
                // Get customer from business layer (Core App)
                List<KiralikBilgi> kiralikbilgiler = null;
                try
                {
                    var c = kiralikBilgiBusiness.SelectById(id);
                    if (c != null)
                    {
                        kiralikbilgiler = new List<KiralikBilgi>();
                        kiralikbilgiler.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<KiralikBilgi>(kiralikbilgiler);

                    // Return content as a json and proper http response
                    return new XmlResult<KiralikBilgi>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<KiralikBilgi>(null);
                    return new XmlResult<KiralikBilgi>(content, Request);
                }
            }
        }

        public IHttpActionResult Post([FromBody]KiralikBilgi kiralikbilgi)
        {
            var content = new ResponseContent<KiralikBilgi>(null);
            if (kiralikbilgi != null)
            {
                using (var kiralikBilgiBusiness = new KiralikBilgiBusiness())
                {
                    content.Result = kiralikBilgiBusiness.Ekle(kiralikbilgi) ? "1" : "0";

                    return new StandartResult<KiralikBilgi>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<KiralikBilgi>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<KiralikBilgi>(null);

            using (var kiralikBilgiBusiness = new KiralikBilgiBusiness())
            {
                content.Result = kiralikBilgiBusiness.DeleteById(id) ? "1" : "0";

                return new StandartResult<KiralikBilgi>(content, Request);
            }
        }
    }
}