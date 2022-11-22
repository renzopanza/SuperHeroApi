using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.src.Models
{
    public class SuperHeroi
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string PrimeiroNome { get; set; } = string.Empty;
        [Required]
        public string UltimoNome { get; set; } = string.Empty;
        [Required]
        public string CidadeNatal { get; set; } = string.Empty;
    }
}
