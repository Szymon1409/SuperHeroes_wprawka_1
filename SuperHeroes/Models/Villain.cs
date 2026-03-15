using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Models
{
    public class Villain
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string EvilPlan { get; set; }
        public int LairId { get; set; }
        public virtual Lair Lair { get; set; }
        public virtual ICollection<VillainWeapon> VillainWeapon { get; set; } = new List<VillainWeapon>();
    }
}
