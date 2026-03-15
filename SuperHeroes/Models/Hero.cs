using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Models
{
    public class Hero
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Bio { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>(); 
    }
}
