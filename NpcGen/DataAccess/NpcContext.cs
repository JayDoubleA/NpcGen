using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.DataAccess
{
    public class NpcContext : DbContext
    {
        public DbSet<ClassModel> Classes { get; set; }
   //     public DbSet<GeneralAppearanceModel> GeneralAppearances { get; set; }
 //       public DbSet<FaceModel> FaceFeatures { get; set; }
        public DbSet<AttackModel> Attacks { get; set; }
        public DbSet<MagicModel> Magics { get; set; }
        public DbSet<QuirkModel> Quirks { get; set; }
        public DbSet<DemeanourModel> Demeanours { get; set; }
        public DbSet<ProficiencyModel> Proficiencies { get; set; }
        public DbSet<ClassAbilityModel> ClassAbilities { get; set; }
        public DbSet<AppearanceFeatureModel> AppearanceFeatures { get; set; }

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
                HasMany(c => c.Attacks);

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
        }
    }
}