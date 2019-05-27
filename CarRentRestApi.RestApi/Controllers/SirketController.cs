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
    public class SirketController :ApiController
    {
        public IHttpActionResult Get()
        {
            using (var sirketBusiness = new SirketBusiness())
            {
                // Get customers from business layer (Core App)
                List<Sirket> sirketler = sirketBusiness.ListAll();

                // Prepare a content
                var content = new ResponseContent<Sirket>(sirketler);

                // Return content as a json and proper http response
                return new StandartResult<Sirket>(content, Request);
            }
        }

        public IHttpActionResult Get(int id)
        {
            ResponseContent<Sirket> content;

            using (var sirketBusiness = new SirketBusiness())
            {
                // Get customer from business layer (Core App)
                List<Sirket> sirketler = null;
                try
                {
                    var c = sirketBusiness.SelectById(id);
                    if (c != null)
                    {
                        sirketler = new List<Sirket>();
                        sirketler.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<Sirket>(sirketler);

                    // Return content as a json and proper http response
                    return new XmlResult<Sirket>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<Sirket>(null);
                    return new XmlResult<Sirket>(content, Request);
                }
            }
        }

        public IHttpActionResult Post([FromBody]Sirket sirket)
        {
            var content = new ResponseContent<Sirket>(null);
            if (sirket != null)
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    content.Result = sirketBusiness.Ekle(sirket) ? "1" : "0";

                    return new StandartResult<Sirket>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Sirket>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Sirket>(null);

            using (var sirketBusiness = new SirketBusiness())
            {
                content.Result = sirketBusiness.DeleteById(id) ? "1" : "0";

                return new StandartResult<Sirket>(content, Request);
            }
        }
    }
}