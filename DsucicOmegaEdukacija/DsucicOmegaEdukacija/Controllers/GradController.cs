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
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, gradovi.Gradovi.ToList());
            }
        }
        //GET/id
        [Authorize(Roles = "Administrator")]
        public HttpResponseMessage Get(Guid id)
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                var grad = gradovi.Gradovi.FirstOrDefault(e => e.GradId == id);

                if (grad != null)
                    return Request.CreateResponse(HttpStatusCode.OK, grad);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Grad s GUID-om = " + id.ToString() + " nije pronađen!");
            }
        }

    }
}