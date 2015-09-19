using NpcGen.Constants;

namespace NpcGen.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.NpcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NpcGen.DataAccess.NpcContext";
        }

        protected override void Seed(DataAccess.NpcContext context)
        {
            var proflist = ProficiencyDefinitions.List();
            foreach (var prof in proflist)
            {
                context.Proficiencies.AddOrUpdate(r => r.ProficiencyId, prof);
            }

            var abs = ClassAbilityDefinitions.List();
            foreach (var ab in abs)
            {
                context.ClassAbilities.AddOrUpdate(r => r.Name, ab);
            }

            var classlist = ClassDefinitions.List(proflist, abs);
            foreach (var cls in classlist)
            {
                context.Classes.AddOrUpdate(r => r.Name, cls);
            }

            var quirkslist = QuirkDefinitions.List();
            foreach (var qrk in quirkslist)
            {
                context.Quirks.AddOrUpdate(r => r.QuirkId, qrk);
            }

            var demeanourlist = DemeanourDefinitions.List();
            foreach (var dem in demeanourlist)
            {
                context.Demeanours.AddOrUpdate(r => r.DemeanourId, dem);
            }

            var featureslist = FeatureDefinitions.List();
            foreach (var ftr in featureslist)
            {
                context.FaceFeatures.AddOrUpdate(r => r.FaceId, ftr);
            }
        }
    }
}
