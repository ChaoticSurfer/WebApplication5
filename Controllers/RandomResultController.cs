using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomResultController : ControllerBase
    {
        private readonly RandomNumberGeneratorService randomSerivce1;
        private readonly RandomNumberGeneratorService randomSerivce2;

        public RandomResultController(
            RandomNumberGeneratorService randomSerivce1,
            RandomNumberGeneratorService randomSerivce2)
        {
            this.randomSerivce1 = randomSerivce1;
            this.randomSerivce2 = randomSerivce2;
        }
        [HttpGet]
        public string GetRandomResult()
        {
            return $"{randomSerivce1.RandomString} -------- {randomSerivce2.RandomString}";
        }
    }
}
