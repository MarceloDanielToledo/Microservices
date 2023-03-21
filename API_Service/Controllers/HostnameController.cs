using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_ServiceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HostnameController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var hostname = Dns.GetHostName();
            return "Hi! - from: " + hostname;
        }
    }
}
