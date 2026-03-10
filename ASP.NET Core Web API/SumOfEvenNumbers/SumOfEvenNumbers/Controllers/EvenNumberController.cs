using Microsoft.AspNetCore.Mvc;

namespace SumOfEvenNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenNumberController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if(i % 2 == 0) sum = sum + i;
            }

            return Ok(sum);
        }
    }
}
