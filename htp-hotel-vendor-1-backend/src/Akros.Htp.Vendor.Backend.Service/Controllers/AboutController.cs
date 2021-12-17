using Microsoft.AspNetCore.Mvc;

namespace Akros.Htp.Vendor.Backend.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        protected ActionResult Get()
        {
            return Ok("someText for some reason");
        }
    }
}
