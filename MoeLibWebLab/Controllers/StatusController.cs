using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoeLibWebLab.Controllers
{
    [RoutePrefix("Status")]
    public class StatusController : ApiController
    {
        [HttpGet, HttpPost, Route("BadRequest")]
        public IHttpActionResult BadRequestResult()
        {
            return this.BadRequest();
        }

        [HttpGet, HttpPost, Route("BadRequestContent")]
        public IHttpActionResult BadRequestResultWithContent()
        {
            return this.BadRequest("BadRequestContent");
        }

        [HttpGet, HttpPost, Route("InternalServerError")]
        public IHttpActionResult InternalServerErrorResult()
        {
            return this.InternalServerError();
        }

        [HttpGet, HttpPost, Route("InternalServerErrorContent")]
        public IHttpActionResult InternalServerErrorResultWithContent()
        {
            return this.InternalServerError(new ApplicationException("InternalServerErrorContent"));
        }

        [HttpGet, HttpPost, Route("NoContent")]
        public HttpResponseMessage NoContentResult()
        {
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet, HttpPost, Route("NotFound")]
        public IHttpActionResult NotFoundResult()
        {
            return this.NotFound();
        }

        [HttpGet, HttpPost, Route("Ok")]
        public IHttpActionResult OkResult()
        {
            return this.Ok();
        }

        [HttpGet, HttpPost, Route("OkContent")]
        public IHttpActionResult OkResultWithContent()
        {
            return this.Ok(new object());
        }
    }
}