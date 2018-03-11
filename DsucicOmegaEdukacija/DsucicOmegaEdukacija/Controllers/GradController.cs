using DsucicOmegaEdukacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DsucicOmegaEdukacija.Controllers
{
    public class GradController : ApiController
    {
        //GET
        [HttpGet]
        [Authorize(Roles = "Administrator, User")]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, gradovi.Gradovi.ToList());
            }
        }

        //GET/id
        [HttpGet]
        [Authorize(Roles = "Administrator, User")]
        public HttpResponseMessage Get(Guid id)
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                var grad = gradovi.Gradovi.FirstOrDefault(e => e.GradId == id);

                if (grad != null)
                    return Request.CreateResponse(HttpStatusCode.OK, grad);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Grad s GUID-om " + id.ToString() + " nije pronađen!");
            }
        }

        //POST
        [Authorize(Roles = "Administrator")]
        public HttpResponseMessage Post([FromBody]Grad grad)
        {
            try
            {
                using (ApplicationDbContext gradovi = new ApplicationDbContext())
                {
                    gradovi.Gradovi.Add(grad);
                    gradovi.SaveChanges();

                    var poruka = Request.CreateResponse(HttpStatusCode.Created, grad);
                    poruka.Headers.Location = new Uri(Request.RequestUri + grad.GradId.ToString());

                    return poruka;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //DELETE
        [Authorize(Roles = "Administrator")]
        public HttpResponseMessage Delete(Guid id)
        { 
            try
            {
                using (ApplicationDbContext gradovi = new ApplicationDbContext())
                {
                    var grad = gradovi.Gradovi.FirstOrDefault(e => e.GradId == id);
                    if (grad == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Grad s GUID-om " + id.ToString() + " nije pronađen!");
                    else
                    {
                        gradovi.Gradovi.Remove(grad);
                        gradovi.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        //PUT
        [Authorize(Roles = "Administrator")]
        public HttpResponseMessage Put(Guid id, [FromBody]Grad gradBody)
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                try
                {
                    var grad = gradovi.Gradovi.FirstOrDefault(e => e.GradId == id);

                    if (grad == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Grad s GUID-om " + id.ToString() + " nije pronađen!");
                    else
                    {
                        grad.Naziv = gradBody.Naziv;
                        gradovi.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, grad);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }

            }
        }
    }
}