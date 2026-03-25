using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Models;

namespace SuperHeroes.Data
{
    public class HeroesContext : IdentityDbContext<IdentityUser>
    {
        public HeroesContext(DbContextOptions options) : base(options) { }
        public DbSet<Hero> Hero { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Lair> Lairs { get; set; }
        public DbSet<Villain> Villains { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<VillainWeapon> VillainWeapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasOne(e => e.Team)
                .WithMany(e => e.Heroes);

            // 1. Relacja 1:N (One-to-many): Kryjówka i Złoczyńca
            modelBuilder.Entity<Villain>()
                .HasOne(v => v.Lair)
                .WithMany(l => l.Villains)
                .HasForeignKey(v => v.LairId);

            // 2. Relacja N:M (Many-to-many): Złoczyńca i Broń (z tabelą pośrednią)
            modelBuilder.Entity<VillainWeapon>()
                .HasKey(vw => new { vw.VillainId, vw.WeaponId });

            // Łączenie tabeli pośredniej ze Złoczyńcą
            modelBuilder.Entity<VillainWeapon>()
                .HasOne(vw => vw.Villain)
                .WithMany(v => v.VillainWeapon)
                .HasForeignKey(vw => vw.VillainId);

            // Łączenie tabeli pośredniej z Bronią
            modelBuilder.Entity<VillainWeapon>()
                .HasOne(vw => vw.Weapon)
                .WithMany(w => w.VillainWeapon)
                .HasForeignKey(vw => vw.WeaponId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
