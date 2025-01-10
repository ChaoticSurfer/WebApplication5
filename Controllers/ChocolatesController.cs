using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Dtos;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChocolatesController : ControllerBase
    {
        private readonly IChocolateRepository _chocolateRepository;

        public ChocolatesController(IChocolateRepository chocolateRepository)
        {
            _chocolateRepository = chocolateRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chocolate>>> GetChocolates()
        {
            return Ok(await _chocolateRepository.GetChocolatesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chocolate>> GetChocolate(int id)
        {
            var chocolate = await _chocolateRepository.GetChocolateByIdAsync(id);

            if (chocolate == null)
            {
                return NotFound();
            }

            return Ok(chocolate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChocolate(int id, Chocolate chocolateDto)
        {
            if (id != chocolateDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _chocolateRepository.UpdateChocolateAsync(chocolateDto);
            }
            catch
            {
                if (!await _chocolateRepository.ChocolateExistsAsync(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Chocolate>> PostChocolate(ChocolateDto chocolateDto)
        {
            var chocolate = chocolateDto.ToChocolate();
            await _chocolateRepository.AddChocolateAsync(chocolate);

            return CreatedAtAction(nameof(GetChocolate), new { id = chocolate.Id }, chocolate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChocolate(int id)
        {
            if (!await _chocolateRepository.ChocolateExistsAsync(id))
            {
                return NotFound();
            }

            await _chocolateRepository.DeleteChocolateAsync(id);
            return NoContent();
        }
    }
}
