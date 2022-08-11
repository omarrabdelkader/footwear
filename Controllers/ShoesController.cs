using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoesAPI.Data;

namespace ShoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
       
        private readonly DataContext _context;
        public ShoesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var shoes = await _context.ShoesTable.ToListAsync();
            return Ok(shoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shoesById = await _context.ShoesTable.FindAsync(id);
            if(shoesById == null)
            {
                return BadRequest($"Not found, shoes' id = {id} ");
            }
            return Ok(shoesById);   
        }

        [HttpPost]

        public async Task<IActionResult> AddShoes(Shoes newShoes)
        {
            _context.ShoesTable.Add(newShoes);
            //because we have changed something in the table, so we are saving it 
            await _context.SaveChangesAsync();
            return Ok(await _context.ShoesTable.ToListAsync());
        }

        [HttpPut]

        public async Task<IActionResult> UpdateShoes(Shoes request)
        {
            var shoesById = await _context.ShoesTable.FindAsync(request.Id);
            if (shoesById == null)
            {
                return BadRequest($"Not found, shoes' id = {request.Id} ");
            }

            shoesById.Title = request.Title;
            shoesById.Size = request.Size;
            shoesById.Type = request.Type;

            await _context.SaveChangesAsync();

            return Ok(await _context.ShoesTable.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoes(Shoes request)
        {
            var requestedShoes = await _context.ShoesTable.FindAsync(request.Id);

            _context.ShoesTable.Remove(requestedShoes);

            await _context.SaveChangesAsync();

            return Ok(await _context.ShoesTable.ToListAsync());
        }



    }
}
