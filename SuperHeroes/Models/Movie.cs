using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public ICollection<Hero> Heroes { get; set; } = new List<Hero>();
    }
}
