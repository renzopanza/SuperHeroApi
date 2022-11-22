using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.src.Context;
using SuperHeroAPI.src.Models;

namespace SuperHeroAPI.src.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroiController : ControllerBase
    {
        private static List<SuperHeroi> herois = new List<SuperHeroi>{

            new SuperHeroi
                {
                    Id=2,
                    Nome="Homem de Ferro",
                    PrimeiroNome="Tony",
                    UltimoNome="Stark",
                    CidadeNatal="Nova York"
                },

            new SuperHeroi
            {
                Id=3,
                Nome="Homem de Ferro",
                    PrimeiroNome="Tony",
                    UltimoNome="Stark",
                    CidadeNatal="Nova York"
            }
        };
        private readonly HeroiContext context;

        public SuperHeroiController(HeroiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroi>>> Get()
        {
            return Ok(herois);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroi>> Get(int id)
        {
            var heroi = await context.SuperHerois.FindAsync(id);
            if (heroi == null)
            {
                return BadRequest("Herói não encontrado!");
            }
            return Ok(heroi);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHeroi>>> AddHeroi(SuperHeroi heroi)
        {

            context.SuperHerois.Add(heroi);
            await context.SaveChangesAsync();
            return Ok("Herói adicionado com sucesso!");

        }

        [HttpPut]
        public async Task<ActionResult<SuperHeroi>> UpdateHeroi(SuperHeroi request)
        {
            var dbHeroi = await context.SuperHerois.FindAsync(request.Id);
            if (dbHeroi == null)
            {
                return BadRequest("Herói não encontrado!");
            }

            dbHeroi.Id = request.Id;
            dbHeroi.Nome = request.Nome;
            dbHeroi.PrimeiroNome = request.PrimeiroNome;
            dbHeroi.UltimoNome = request.UltimoNome;
            dbHeroi.CidadeNatal = request.CidadeNatal;

            await context.SaveChangesAsync();
            return Ok("Update realizado com sucesso!");

        }

        [Route("RemoverHeroi")]
        [HttpDelete]
        public async Task<ActionResult<SuperHeroi>> DeleteHero(int id)
        {
            var dbHeroi = await context.SuperHerois.FindAsync(id);
            if (dbHeroi == null)
            {
                return BadRequest("Herói não encontrado!");
            }
            context.SuperHerois.Remove(dbHeroi);
            await context.SaveChangesAsync();
            return Ok("Herói removido!");
        }
    }
}
