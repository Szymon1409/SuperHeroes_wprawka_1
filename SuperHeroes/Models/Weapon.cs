using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Damage { get; set; }
        public virtual ICollection<VillainWeapon> VillainWeapon { get; set; } = new List<VillainWeapon>();
    }
}
