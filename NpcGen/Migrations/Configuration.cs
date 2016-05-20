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

            var attackProps = AtackPropertyDefinitions.List();
            foreach (var prop in attackProps)
            {
                context.AttackProperties.AddOrUpdate(r => r.Name, prop);
            }

            var attacklist = AttackDefinitions.List(attackProps);
            foreach (var attack in attacklist)
            {
                context.Attacks.AddOrUpdate(r => r.Name, attack);
            }

            var proflist = ProficiencyDefinitions.List();
            foreach (var prof in proflist)
            {
                context.Proficiencies.AddOrUpdate(r => r.Id, prof);
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
                context.Demeanours.AddOrUpdate(r => r.Id, dem);
            }

            var appearanceList = AppearanceDefinitions.Features();
            foreach (var featue in appearanceList)
            {
                context.AppearanceFeatures.AddOrUpdate(r => r.Name, featue);
            }

            var raceAbilityList = RaceAbilityDefinitions.RaceAbilitiesList();
            foreach (var ab in raceAbilityList)
            {
                context.RaceAbilities.AddOrUpdate(r => r.Name, ab);
            }

            var raceDef = new RaceDefinitions{AbilityList = raceAbilityList, ProficiencyList = proflist};
            var raceList = raceDef.RacesList();
            foreach (var race in raceList)
            {
                context.Races.AddOrUpdate(r => r.Name, race);
            }

            var locationsDef = new LocationDefinitions
            {
                AppearancesList = appearanceList,
                Attacks = attacklist,
                ProficienciesList = proflist,
                Races = raceList
            };
            locationsDef.LocationsPreinit();
            var locsList = locationsDef.LocationsList();
            foreach (var loc in locsList)
            {
                context.Locations.AddOrUpdate(l => l.Name, loc);
            }
        }
    }
}
