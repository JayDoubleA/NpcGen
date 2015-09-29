using NpcGen.Constants;
using NpcGen.DataAccess;

namespace NpcGen.Migrations
{
    using Models.NpcModels;
    using System.Data.Entity.Migrations;

    public class Configuration : DbMigrationsConfiguration<NpcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NpcGen.DataAccess.NpcContext";
        }

        public void SeedDebug(NpcContext context)
        {
            Seed(context);
        }

        protected override void Seed(NpcContext context)
        {
            var magicNone = new MagicModel { MagicName = "None" };
            context.Magics.AddOrUpdate(r => r.MagicName, magicNone);

            var attacklist = AttackDefinitions.List();
            foreach (var attack in attacklist)
            {
                context.Attacks.AddOrUpdate(r => r.Name, attack);
            }

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

            var clsDef = new ClassDefinitions();
            var classlist = clsDef.List(proflist, abs, attacklist);
            foreach (var cls in classlist)
            {
                context.Classes.AddOrUpdate(r => r.Name, cls);
            }

            var quirkslist = QuirkDefinitions.List();
            foreach (var qrk in quirkslist)
            {
                context.Quirks.AddOrUpdate(r => r.Description, qrk);
            }

            var demeanourlist = DemeanourDefinitions.List();
            foreach (var dem in demeanourlist)
            {
                context.Demeanours.AddOrUpdate(r => r.DemeanourId, dem);
            }

            var hairColourList = AppearanceDefinitions.HairColours();
            foreach (var colour in hairColourList)
            {
                context.AppearanceFeatures.AddOrUpdate(r => r.Name, colour);
            }

            var hairStyleList = AppearanceDefinitions.Hairstyles();
            foreach (var style in hairStyleList)
            {
                context.AppearanceFeatures.AddOrUpdate(r => r.Name, style);
            }
        }
    }
}
