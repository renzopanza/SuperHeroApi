using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.src.Models;

namespace SuperHeroAPI.src.Context
{
    public class HeroiContext : DbContext
    {
        public HeroiContext (DbContextOptions<HeroiContext> options) : base(options) { }

        public DbSet<SuperHeroi> SuperHerois { get; set; } 
    }
}
