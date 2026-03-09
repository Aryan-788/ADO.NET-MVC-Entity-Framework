using Microsoft.AspNetCore.Mvc;

namespace AddThreeNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNumbers : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(int a, int b, int c)
        {
            var result = new
            {
                FirstNumber = a,
                SecondNumber = b,
                ThirdNumber = c,
                Sum = a + b + c

            };
           
            return Ok(result);
        }
    }
}
