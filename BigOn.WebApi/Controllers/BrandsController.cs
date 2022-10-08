using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("from get");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("from post");
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return Ok("from put");
        }

        [HttpDelete]
        public IActionResult Remove()
        {
            return Ok("from delete");
        }
    }
}
