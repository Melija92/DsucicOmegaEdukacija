using DsucicOmegaEdukacija.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DsucicOmegaEdukacija.Controllers
{
    public class KontaktController : ApiController
    {
        //GET
        [HttpGet]
        [Authorize(Roles = "Administrator, User")]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext kontakti = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, kontakti.Kontakti.ToList());
            }
        }

        //GET/id
        [HttpGet]
        [Authorize(Roles = "Administrator, User")]
        public HttpResponseMessage Get(Guid id)
        {
            using (ApplicationDbContext kontakti = new ApplicationDbContext())
            {
                var kontakt = kontakti.Kontakti.FirstOrDefault(e => e.KontaktId == id);
                
                if (kontakt != null)
                    return Request.CreateResponse(HttpStatusCode.OK, kontakt);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Kontakt s GUID-om " + id.ToString() + " nije pronađen!");
            }
        }

        //POST
        [Authorize(Roles = "Administrator")]
        public HttpResponseMessage Post([FromBody]Kontakt kontakt)
        {
            try
            {
                using (ApplicationDbContext kontakti = new ApplicationDbContext())
                {
                    kontakti.Kontakti.Add(kontakt);
                    kontakti.SaveChanges();

                    var poruka = Request.CreateResponse(HttpStatusCode.Created, kontakt);
                    poruka.Headers.Location = new Uri(Request.RequestUri + kontakt.KontaktId.ToString());

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
                using (ApplicationDbContext kontakti = new ApplicationDbContext())
                {
                    var kontakt = kontakti.Kontakti.FirstOrDefault(e => e.KontaktId == id);
                    if (kontakt == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Kontakt s GUID-om " + id.ToString() + " nije pronađen!");
                    else
                    {
                        kontakti.Kontakti.Remove(kontakt);
                        kontakti.SaveChanges();

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
        public HttpResponseMessage Put(Guid id, [FromBody]Kontakt kontaktBody)
        {
            using (ApplicationDbContext kontakti = new ApplicationDbContext())
            {
                try
                {
                    var kontakt = kontakti.Kontakti.FirstOrDefault(e => e.KontaktId == id);

                    if (kontakt == null)
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kontakt s GUID-om " + id.ToString() + " nije pronađen!");
                    else
                    {
                        kontakt.Ime = kontaktBody.Ime;
                        kontakt.Prezime = kontaktBody.Prezime;
                        kontakt.GradId = kontaktBody.GradId;

                        kontakti.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, kontakt);
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