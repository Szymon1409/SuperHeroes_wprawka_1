using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
