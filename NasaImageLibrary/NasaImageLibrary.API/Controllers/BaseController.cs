using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NasaImageLibrary.API.Controllers
{
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
       
    }
}
