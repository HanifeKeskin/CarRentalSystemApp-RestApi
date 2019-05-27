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
    public class MusterilerController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var musterilerBusiness = new MusterilerBusiness())
            {
                // Get customers from business layer (Core App)
                List<Musteriler> musteriler = musterilerBusiness.ListAll();

                // Prepare a content
                var content = new ResponseContent<Musteriler>(musteriler);

                // Return content as a json and proper http response
                return new StandartResult<Musteriler>(content, Request);
            }
        }

        public IHttpActionResult Get(int id)
        {
            ResponseContent<Musteriler> content;

            using (var musterilerBusiness = new MusterilerBusiness())
            {
                // Get customer from business layer (Core App)
                List<Musteriler> musteriler = null;
                try
                {
                    var c = musterilerBusiness.SelectById(id);
                    if (c != null)
                    {
                        musteriler = new List<Musteriler>();
                        musteriler.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<Musteriler>(musteriler);

                    // Return content as a json and proper http response
                    return new XmlResult<Musteriler>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<Musteriler>(null);
                    return new XmlResult<Musteriler>(content, Request);
                }
            }
        }

        public IHttpActionResult Post([FromBody]Musteriler musteriler)
        {
            var content = new ResponseContent<Musteriler>(null);
            if (musteriler != null)
            {
                using (var musterilerBusiness = new MusterilerBusiness())
                {
                    content.Result = musterilerBusiness.Ekle(musteriler) ? "1" : "0";

                    return new StandartResult<Musteriler>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Musteriler>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Musteriler>(null);

            using (var musterilerBusiness = new MusterilerBusiness())
            {
                content.Result = musterilerBusiness.DeleteById(id) ? "1" : "0";

                return new StandartResult<Musteriler>(content, Request);
            }
        }


    }
}