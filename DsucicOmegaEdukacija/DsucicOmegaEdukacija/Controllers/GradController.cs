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
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (ApplicationDbContext gradovi = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, gradovi.Gradovi.ToList());
            }
        }
    }
}