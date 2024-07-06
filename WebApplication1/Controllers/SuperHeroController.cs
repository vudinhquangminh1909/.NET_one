using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var Heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroe(int id)
        {
            var Hero = await _context.SuperHeroes.FindAsync(id);

            if(Hero is null)
                return NotFound("Hero not found.");

            return Ok(Hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpHero(SuperHero Updatehero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(Updatehero.Id);
            if (dbHero is null)
                return NotFound("Hero not found.");
            dbHero.Name = Updatehero.Name;
            dbHero.FirstName = Updatehero.FirstName;
            dbHero.LastName = Updatehero.LastName;  
            dbHero.Place = Updatehero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null)
                return NotFound("Hero not found.");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
