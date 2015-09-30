using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.DataAccess
{
    public class NpcContext : DbContext
    {
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<AttackModel> Attacks { get; set; }
        public DbSet<MagicModel> Magics { get; set; }
        public DbSet<QuirkModel> Quirks { get; set; }
        public DbSet<DemeanourModel> Demeanours { get; set; }
        public DbSet<ProficiencyModel> Proficiencies { get; set; }
        public DbSet<ClassAbilityModel> ClassAbilities { get; set; }
        public DbSet<AppearanceFeatureModel> AppearanceFeatures { get; set; }
        public DbSet<RaceModel> Races { get; set; }
        public DbSet<RaceAbilityModel> RaceAbilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.Proficiencies).
                WithMany(p => p.Classes).
                Map(
                    m =>
                    {
                        m.MapLeftKey("ClassId");
                        m.MapRightKey("ProficiencyId");
                        m.ToTable("ClassesProficiencies");
                    });

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.Attacks).
                WithMany(a => a.Classes).
                Map(m =>
                {
                    m.MapLeftKey("ClassId");
                    m.MapRightKey("AttackId");
                    m.ToTable("ClassesAttacks");
                });

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.ClassAbilities).
                WithMany(a => a.Classes).
                Map(
                    m =>
                    {
                        m.MapLeftKey("ClassId");
                        m.MapRightKey("Name");
                        m.ToTable("ClassesAbilities");
                    });

            modelBuilder.Entity<RaceModel>().
               HasMany(r => r.RaceAbilities).
               WithMany(a => a.Races).
               Map(
                   m =>
                   {
                       m.MapLeftKey("RaceId");
                       m.MapRightKey("RaceAbilityId");
                       m.ToTable("RacesAbilities");
                   });

            modelBuilder.Entity<RaceModel>().
                HasMany(r => r.Proficiencies).
                WithMany(p => p.Races).
                Map(
                    m =>
                    {
                        m.MapLeftKey("RaceId");
                        m.MapRightKey("ProficiencyId");
                        m.ToTable("RacesProficiencies");
                    });
        }
    }
}