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
        public DbSet<LocationModel> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.Proficiencies).
                WithMany(p => p.Classes).
                Map(
                    m =>
                    {
                        m.MapLeftKey("Class");
                        m.MapRightKey("Proficieny");
                        m.ToTable("ClassesProficiencies");
                    });

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.Attacks).
                WithMany(a => a.Classes).
                Map(m =>
                {
                    m.MapLeftKey("Class");
                    m.MapRightKey("Attack");
                    m.ToTable("ClassesAttacks");
                });

            modelBuilder.Entity<ClassModel>().
                HasMany(c => c.ClassAbilities).
                WithMany(a => a.Classes).
                Map(
                    m =>
                    {
                        m.MapLeftKey("Class");
                        m.MapRightKey("Ability");
                        m.ToTable("ClassesAbilities");
                    });

            modelBuilder.Entity<RaceModel>().
               HasMany(r => r.RaceAbilities).
               WithMany(a => a.Races).
               Map(
                   m =>
                   {
                       m.MapLeftKey("Race");
                       m.MapRightKey("Ability");
                       m.ToTable("RacesAbilities");
                   });

            modelBuilder.Entity<RaceModel>().
                HasMany(r => r.Proficiencies).
                WithMany(p => p.Races).
                Map(
                    m =>
                    {
                        m.MapLeftKey("Race");
                        m.MapRightKey("Proficieny");
                        m.ToTable("RacesProficiencies");
                    });

            modelBuilder.Entity<LocationModel>().
               HasMany(l => l.CulturalProficiencies).
               WithMany(p => p.Locations).
               Map(
                   m =>
                   {
                       m.MapLeftKey("Location");
                       m.MapRightKey("Proficieny");
                       m.ToTable("LocationsProficiencies");
                   });

            modelBuilder.Entity<LocationModel>().
               HasMany(l => l.AppearanceFeatureModel).
               WithMany(p => p.Locations).
               Map(
                   m =>
                   {
                       m.MapLeftKey("Locations");
                       m.MapRightKey("Appearance");
                       m.ToTable("LocationsAppearances");
                   });

            modelBuilder.Entity<LocationModel>().
               HasMany(l => l.MajorRaces).
               WithMany(r => r.LocationsMajor).
               Map(
                   m =>
                   {
                       m.MapLeftKey("Location");
                       m.MapRightKey("Race");
                       m.ToTable("LocationsRacesMajor");
                   });

            modelBuilder.Entity<LocationModel>().
               HasMany(l => l.AbsentRaces).
               WithMany(r => r.LocationsAbsent).
               Map(
                   m =>
                   {
                       m.MapLeftKey("Location");
                       m.MapRightKey("Race");
                       m.ToTable("LocationsRacesAbsent");
                   });

            modelBuilder.Entity<LocationModel>().
               HasMany(l => l.LocationCloseTies).
               WithMany().
               Map(
                   m =>
                   {
                       m.MapLeftKey("Locations");
                       m.MapRightKey("Locations2");
                       m.ToTable("LocationsLocationsClose");
                   });

            modelBuilder.Entity<LocationModel>().
              HasMany(l => l.LocationDistantTies).
              WithMany().
              Map(
                  m =>
                  {
                      m.MapLeftKey("Locations");
                      m.MapRightKey("Locations2");
                      m.ToTable("LocationsLocationsDistant");
                  });

            modelBuilder.Entity<LocationModel>().
             HasMany(l => l.CulturalWeapons).
             WithMany(a => a.Locations).
             Map(
                 m =>
                 {
                     m.MapLeftKey("Locations");
                     m.MapRightKey("Attack");
                     m.ToTable("LocationsAttacks");
                 });
        }
    }
}