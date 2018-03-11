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
    public class KontaktController : ApiController
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext kontakti = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, kontakti.Kontakti.ToList());
            }
        }
    }
}