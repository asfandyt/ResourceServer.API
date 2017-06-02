using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace ResourceServer.Api.Controllers
{
    
    [RoutePrefix("api/protected")]
    public class ProtectedController : ApiController
    {
        [Authorize]
        [Route("claims")]
        public IEnumerable<object> Get()
        {
            var identity = User.Identity as ClaimsIdentity;

            return identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
    }
}