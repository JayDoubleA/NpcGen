using System.Collections.Generic;
using System.Linq;
using NpcGen.Enums;
using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public class LocationDefinitions
    {
        public List<RaceModel> Races { get; set; }
        public List<AppearanceFeatureModel> AppearancesList { get; set; }
        public List<ProficiencyModel> ProficienciesList { get; set; }
        public List<AttackModel> Attacks { get; set; }

        public void LocationsPreinit()
        {
            AppearancesInit();
            ProficienciesInit();
            AttacksInit();
            LocationsInit();
        }

        private void LocationsInit()
        {
            //  LocattionsPreinit();

            NorthernShores = new LocationModel("The Northern Shores", "The far North, where winter lasts half the year.")
            {
                MajorRaces = Races.Where(x => x.Race.Equals(Race.Human) || x.Race.Equals(Race.Dwarf)).ToList(),
                AppearanceFeatureModels =
                    AppearancesList.Where(x => NorthernShoresAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies =
                    ProficienciesList.Where(x => NorthernShoresProficiencies.Contains(x.Id)).ToList(),
                AbsentRaces = Races.Where(x => x.Race.Equals(Race.Gnome) || x.Race.Equals(Race.Halfling)).ToList(),
                CulturalWeapons = Attacks.Where(x => NorthernShoresWeapons.Contains(x.Name)).ToList()
            };

            WesternIsles = new LocationModel("The Western Isles",
                "The islands at the end of the world, overlooking the great ocean.")
            {
                MajorRaces = Races.Where(x => !x.Race.Equals(Race.Halfling) || !x.Race.Equals(Race.Gnome)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => WesternIslesAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => WesternIslesProficiencies.Contains(x.Id)).ToList(),
                AbsentRaces = Races.Where(x => x.Race.Equals(Race.Gnome) || x.Race.Equals(Race.Halfling)).ToList(),
                CulturalWeapons = Attacks.Where(x => WesternIslesWeapons.Contains(x.Name)).ToList()
            };

            HeartLand = new LocationModel("The Heartlands", "The northern and central lands, mountainous and forested.")
            {
                MajorRaces = Races.ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => HeartlandAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => HeartlandProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => HeartlandWeapons.Contains(x.Name)).ToList()
            };

            InnerSea = new LocationModel("The Inner Sea",
                "Calm waters and warm coasts, olive groves and white buildings.")
            {
                MajorRaces = Races.Where(x => !x.Race.Equals(Race.Dwarf)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => InnerSeaAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => InnerSeaProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => InnerSeaWeapons.Contains(x.Name)).ToList()
            };
            
            TropicalSouth = new LocationModel("The Tropical South",
                "Rich grasslands give way to deserts punctated with oases, or to thick rainforests.")
            {
                MajorRaces = Races.Where(x => x.Race.Equals(Race.Human)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => TropicalSouthAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => TropicalSouthProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => TropicalSouthWeapons.Contains(x.Name)).ToList(),
                AbsentRaces =
                    Races.Where(
                        x =>
                            x.Race.Equals(Race.Dwarf) || x.Race.Equals(Race.Elf) || x.Race.Equals(Race.Halfling) ||
                            x.Race.Equals(Race.Gnome)).ToList()
            };

            EasternPlains = new LocationModel("The Eastern Plains",
                "Seas of grass and arid steppes, doteed with cites standing on rivers.")
            {
                MajorRaces = Races.Where(x => x.Race.Equals(Race.Human)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => EasternPlainsAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => EasternPlainsProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => EasternPlainsWeapons.Contains(x.Name)).ToList(),
                AbsentRaces =
                    Races.Where(
                        x =>
                            x.Race.Equals(Race.Dwarf) || x.Race.Equals(Race.Elf) || x.Race.Equals(Race.Halfling) ||
                            x.Race.Equals(Race.Gnome)).ToList()
            };

            ElfWoods = new LocationModel("The Elven Woods",
                "Ancient forests, where sylvan creatures still dwell in hidden clearings.")
            {
                MajorRaces = Races.Where(x => x.Race.Equals(Race.Elf)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => ElfWoodsAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => ElfWoodsProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => ElfWoodsWeapons.Contains(x.Name)).ToList(),
                AbsentRaces = Races.Where(x => !x.Race.Equals(Race.Elf) || !x.Race.Equals(Race.HalfElf)).ToList()
            };

            Dwarfholds = new LocationModel("The Dwarf Holds", "Vast cities, extending deep underground.")
            {
                MajorRaces = Races.Where(x => x.Race.Equals(Race.Dwarf)).ToList(),
                AppearanceFeatureModels = AppearancesList.Where(x => DwarfHoldsAppearances.Contains(x.Name)).ToList(),
                CulturalProficiencies = ProficienciesList.Where(x => DwarfHoldsProficiencies.Contains(x.Id)).ToList(),
                CulturalWeapons = Attacks.Where(x => DwarfHoldsWeapons.Contains(x.Name)).ToList(),
                AbsentRaces = Races.Where(x => !x.Race.Equals(Race.Dwarf) || !x.Race.Equals(Race.Gnome)).ToList()
            };

            LocationTiesAdd();
        }

        private void LocationTiesAdd()
        {
            NorthernShores.LocationCloseTies = new List<LocationModel> {WesternIsles, HeartLand};
            NorthernShores.LocationDistantTies = new List<LocationModel> {Dwarfholds};
            WesternIsles.LocationCloseTies = new List<LocationModel> {NorthernShores, HeartLand};
            WesternIsles.LocationDistantTies = new List<LocationModel> {ElfWoods};
            HeartLand.LocationCloseTies = new List<LocationModel> {WesternIsles, NorthernShores, InnerSea};
            HeartLand.LocationDistantTies = new List<LocationModel> {ElfWoods, Dwarfholds};
            InnerSea.AbsentRaces = Races.Where(x => x.Race.Equals(Race.Dwarf)).ToList();
            InnerSea.LocationCloseTies = new List<LocationModel> {HeartLand, TropicalSouth, EasternPlains};
            TropicalSouth.LocationCloseTies = new List<LocationModel> {InnerSea};
            EasternPlains.LocationCloseTies = new List<LocationModel> {InnerSea};
            ElfWoods.LocationDistantTies = new List<LocationModel> {WesternIsles, HeartLand};
            Dwarfholds.LocationDistantTies = new List<LocationModel> {NorthernShores, HeartLand};
        }

        public List<LocationModel> LocationsList()
        {
            var list = new List<LocationModel>();

            list.AddRange(LocationArchetypes());

            return list;
        }

        public List<LocationModel> LocationArchetypes()
        {
            var list = new List<LocationModel>
            {
                NorthernShores,
                WesternIsles,
                HeartLand,
                InnerSea,
                TropicalSouth,
                EasternPlains,
                ElfWoods,
                Dwarfholds
            };

            return list;
        }

        private void AppearancesInit()
        {
            NorthernShoresAppearances = new List<string>
            {
                "Blonde",
                "Platinum Blonde",
                "Braided",
                "Long",
                "Tumbling",
                "EyesBlue",
                "EyesGrey",
                "SkinPale",
                "SkinFair"
            };

            WesternIslesAppearances = new List<string>
            {
                "Blonde",
                "Strawberry Blonde",
                "Ginger",
                "ShoulderLength",
                "Long",
                "ShortTail",
                "EyesGreen",
                "EyesGrey",
                "SkinPale",
                "SkinFair"
            };

            HeartlandAppearances = new List<string>
            {
                "Brown",
                "Dark Blonde",
                "Light Brown",
                "ShoulderLength",
                "ShortMale",
                "ShortTail",
                "EyesBlue",
                "EyesBrwon",
                "SkinTanned",
                "SkinFair"
            };

            InnerSeaAppearances = new List<string>
            {
                "Brown",
                "Light Brown",
                "Black",
                "ShoulderLength",
                "ShortMale",
                "LooseCurls",
                "EyesBrown",
                "SkinTanned",
                "SkinMed"
            };

            TropicalSouthAppearances = new List<string>
            {
                "Dark Brown",
                "Black",
                "Fro",
                "Braided",
                "Bald",
                "EyesBrown",
                "SkinDark"
            };

            EasternPlainsAppearances = new List<string>
            {
                "Dark Brown",
                "Black",
                "LongTailMale",
                "Long",
                "LooseCurls",
                "ShortTail",
                "EyesBrown",
                "SkinMed",
                "SkinOriental"
            };

            ElfWoodsAppearances = new List<string>
            {
                "Sunkissed",
                "Dark",
                "Fair",
                "Long",
                "LongTailFemale",
                "Cascading",
                "EyesGreenElf",
                "EyesGreyElf",
                "EyesBlueElf",
                "SkinPale",
                "SkinPaleElf",
                "SkinFair"
            };

            DwarfHoldsAppearances = new List<string>
            {
                "Black",
                "Dark",
                "Grey",
                "BraidedDwarf",
                "ShortTail",
                "LongTailMale",
                "EyesBright",
                "SkinTanned"
            };
        }

        private void ProficienciesInit()
        {
            NorthernShoresProficiencies = new List<Proficiencies>
            {
                Proficiencies.Survival,
                Proficiencies.Vehicle
            };

            WesternIslesProficiencies = new List<Proficiencies>
            {
                Proficiencies.Performance,
                Proficiencies.Nature
            };

            HeartlandProficiencies = new List<Proficiencies>
            {
                Proficiencies.Religion,
                Proficiencies.ArtisanTools
            };

            InnerSeaProficiencies = new List<Proficiencies>
            {
                Proficiencies.Deception,
                Proficiencies.Persuasion
            };

            EasternPlainsProficiencies = new List<Proficiencies>
            {
                Proficiencies.AnimalHandling,
                Proficiencies.GamingSet
            };

            TropicalSouthProficiencies = new List<Proficiencies>
            {
                Proficiencies.Survival,
                Proficiencies.Performance
            };

            ElfWoodsProficiencies = new List<Proficiencies>
            {
                Proficiencies.Arcana,
                Proficiencies.History
            };

            DwarfHoldsProficiencies = new List<Proficiencies>
            {
                Proficiencies.ArtisanTools,
                Proficiencies.History
            };
        }

        private void AttacksInit()
        {
            NorthernShoresWeapons = new List<string> {"Battleaxe", "Longsword"};
            WesternIslesWeapons = new List<string> {"Shortsword", "Longbow"};
            HeartlandWeapons = new List<string> {"Greatsword", "Heavy crossbow"};
            InnerSeaWeapons = new List<string> {"Rapier", "Light crossbow"};
            TropicalSouthWeapons = new List<string> {"Spear", "Scimitar"};
            EasternPlainsWeapons = new List<string> {"Shortbow", "Shortsword"};
            ElfWoodsWeapons = new List<string> {"Longbow", "Longsword"};
            DwarfHoldsWeapons = new List<string> {"Battleaxe", "Maul"};
        }

        #region region defs

        #region north

        public LocationModel NorthernShores { get; set; }
        public List<string> NorthernShoresAppearances { get; set; }
        public List<Proficiencies> NorthernShoresProficiencies { get; set; }
        public List<string> NorthernShoresWeapons { get; set; }
        public List<string> NorthernShoresMaleNames { get; set; }
        public List<string> NorthernShoresFemaleNames { get; set; }
        public List<string> NorthernShoresFamilyNames { get; set; }

        #endregion

        #region west

        public LocationModel WesternIsles { get; set; }
        public List<string> WesternIslesAppearances { get; set; }
        public List<Proficiencies> WesternIslesProficiencies { get; set; }
        public List<string> WesternIslesWeapons { get; set; }
        public List<string> WesternIslesMaleNames { get; set; }
        public List<string> WesternIslesFemaleNames { get; set; }
        public List<string> WesternIslesFamilyNames { get; set; }

        #endregion

        #region heartland

        public LocationModel HeartLand { get; set; }
        public List<string> HeartlandAppearances { get; set; }
        public List<Proficiencies> HeartlandProficiencies { get; set; }
        public List<string> HeartlandWeapons { get; set; }
        public List<string> HeartlandMaleNames { get; set; }
        public List<string> HeartlandFemaleNames { get; set; }
        public List<string> HeartlandFamilyNames { get; set; }

        #endregion

        #region inner

        public LocationModel InnerSea { get; set; }
        public List<string> InnerSeaAppearances { get; set; }
        public List<Proficiencies> InnerSeaProficiencies { get; set; }
        public List<string> InnerSeaWeapons { get; set; }
        public List<string> InnerSeaMaleNames { get; set; }
        public List<string> InnerSeaFemaleNames { get; set; }
        public List<string> InnerSeaFamilyNames { get; set; }

        #endregion

        #region south

        public LocationModel TropicalSouth { get; set; }
        public List<string> TropicalSouthAppearances { get; set; }
        public List<Proficiencies> TropicalSouthProficiencies { get; set; }
        public List<string> TropicalSouthWeapons { get; set; }
        public List<string> TropicalSouthMaleNames { get; set; }
        public List<string> TropicalSouthFemaleNames { get; set; }
        public List<string> TropicalSouthFamilyNames { get; set; }

        #endregion

        #region east

        public LocationModel EasternPlains { get; set; }
        public List<string> EasternPlainsAppearances { get; set; }
        public List<Proficiencies> EasternPlainsProficiencies { get; set; }
        public List<string> EasternPlainsWeapons { get; set; }
        public List<string> EasternPlainsMaleNames { get; set; }
        public List<string> EasternPlainsFemaleNames { get; set; }
        public List<string> EasternPlainsFamilyNames { get; set; }

        #endregion

        #region world

        public LocationModel WorldCity { get; set; }
        public List<string> WorldCityAppearances { get; set; }
        public List<Proficiencies> WorldCityProficiencies { get; set; }
        public List<string> WorldCityWeapons { get; set; }
        public List<string> WorldCityMaleNames { get; set; }
        public List<string> WorldCityFemaleNames { get; set; }
        public List<string> WorldCityFamilyNames { get; set; }

        #endregion

        #region elves

        public LocationModel ElfWoods { get; set; }
        public List<string> ElfWoodsAppearances { get; set; }
        public List<Proficiencies> ElfWoodsProficiencies { get; set; }
        public List<string> ElfWoodsWeapons { get; set; }
        public List<string> ElfWoodsMaleNames { get; set; }
        public List<string> ElfWoodsFemaleNames { get; set; }
        public List<string> ElfWoodsFamilyNames { get; set; }

        #endregion

        #region north

        public LocationModel Dwarfholds { get; set; }
        public List<string> DwarfHoldsAppearances { get; set; }
        public List<Proficiencies> DwarfHoldsProficiencies { get; set; }
        public List<string> DwarfHoldsWeapons { get; set; }
        public List<string> DwarfHoldsMaleNames { get; set; }
        public List<string> DwarfHoldsFemaleNames { get; set; }
        public List<string> DwarfHoldsFamilyNames { get; set; }

        #endregion

        #endregion
    }
}