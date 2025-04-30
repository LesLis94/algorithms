using algorithms.Services;
using Microsoft.AspNetCore.Mvc;

namespace algorithms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Calculate(string expression)
        {

            var calcul = new CalculService();
            var result = calcul.CalculetService(expression);
            return Ok(result);
        }
    }
}
