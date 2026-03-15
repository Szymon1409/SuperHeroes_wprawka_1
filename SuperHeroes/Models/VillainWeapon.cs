namespace SuperHeroes.Models
{
    public class VillainWeapon
    {
        public int VillainId { get; set; }
        public virtual Villain Villain { get; set; }
        public int WeaponId { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
