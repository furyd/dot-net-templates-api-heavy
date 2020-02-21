using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Domain.V1.Interfaces;

namespace Template.Api.V1.Controllers
{
    [ApiController]
    [Route("example")]
    public class ExampleController : Controller
    {
        private readonly ITypedExample _example;

        public ExampleController(ITypedExample example)
        {
            _example = example;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromQuery] Domain.V1.Models.Request.Example request) => await _example.Get(request).ConfigureAwait(false);
    }
}