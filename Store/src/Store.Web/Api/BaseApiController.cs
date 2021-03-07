using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
