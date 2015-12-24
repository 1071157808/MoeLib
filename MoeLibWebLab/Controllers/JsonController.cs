using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;

namespace MoeLibWebLab.Controllers
{
    public class AppleResponse
    {
        public string Color { get; set; }

        public int Size { get; set; }
    }

    [RoutePrefix("Json")]
    public class JsonController : ApiController
    {
        [HttpGet]
        [Route("JArray")]
        public IHttpActionResult JArray()
        {
            this.BuildPrincipal();
            List<AppleResponse> apples = new List<AppleResponse>
            {
                new AppleResponse { Color = "Red", Size = 10 },
                new AppleResponse { Color = "Red", Size = 10 }, new AppleResponse { Color = "Red", Size = 10 }
            };
            return this.Ok(apples);
        }

        [HttpGet]
        [Route("JObecjt")]
        public IHttpActionResult JObject()
        {
            this.BuildPrincipal();
            return this.Ok(new AppleResponse { Color = "Red", Size = 10 });
        }

        private void BuildPrincipal()
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "MoeLabClaimName")
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "MoeLabAuthenticationType");
            this.User = new ClaimsPrincipal(identity);
        }
    }
}