﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NpcGen.Constants;
using NpcGen.DataAccess;
using NpcGen.Enums;
using NpcGen.Extensions;
using NpcGen.Helpers;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.ControllerHelpers
{
    public class NpcGenHelper
    {
        private readonly NpcContext _context;
        private readonly Random _rnd;
        private readonly RandomHelper _rndHelper;
        private NpcModel _npc;

        public NpcModel Npc
        {
            get { return _npc; }
            set { _npc = value; }
        }

        public NpcGenHelper(NpcContext context, NpcModel npc = null)
        {
            _npc = npc;
            _context = context;
            _rnd = new Random(Environment.TickCount);
            _rndHelper = new RandomHelper(_context);
        }

        public NpcModel NpcGet(NpcModel para)
        {
            Npc = new NpcModel {Para = para.Para ?? new NpcGenParamsModel()};

            GetNpcClass();
            GetNpcRace();
            GetNpcLocation();
            SplitClassProficiencies();
            GetAge();
            GetCustomProficiencies();
            GetNameAndGender();
            GetQuirks();
            GetDemeanour();
            GetAppearance();
            NpcParamsProcess();
            AddCulturalWeaponProficiency();
            AttackRecalculate();
            GetClassAbilities();

            return Npc;
        }

        private void GetNpcLocation()
        {
            if (Npc.Para.LocationName.IsNullOrEmpty())
            {
                Npc.Location = _rndHelper.Location(Npc.Para.RaceName);
            }
            else
            {
                Npc.Location = _context.Locations.FirstOrDefault(x => x.Name.Equals(Npc.Para.LocationName));
            }
        }

        private void GetAppearance()
        {
            var hairCol = AppearanceFeatureGet(AppearanceType.HairColour);
            var hairStyle = AppearanceFeatureGet(AppearanceType.HairStyle);
            var hair = hairStyle.Description.Replace("{col}", hairCol.Description).Replace("{pos}", Npc.Poss());

            var app = new AppearanceModel
            {
                EyeColour = AppearanceFeatureGet(AppearanceType.Eyes).Description,
                Hair = hair
            };

            //pick one or two facial features
            var rnd = new Random(Environment.TickCount);
            var count = rnd.Next(1, 3);
            var feature1 = EnumExtensions.ToName(EnumExtensions.Of<FacialFeature>());
            app.FacialFeatures =  feature1;
            if (count > 1)
            {
                // if the second feature is a conflict, we just drop it
                var feature2 = EnumExtensions.ToName(EnumExtensions.Of<FacialFeature>());
                if (!feature1.Substring(0, 1).Equals(feature2.Substring(0, 1)))
                {
                    app.FacialFeatures = string.Format("{0}, {1}", feature1, feature2);
                }
            }

            app.AppearanceSearchString = string.Format(
                "{0}  \"{1} eyes\" {2} hair",
                app.FacialFeatures.Replace("{pos}", Npc.Poss()),
                app.EyeColour,
                hairCol.Description
                );

            Npc.Appearance = app;
        }

        private AppearanceFeatureModel AppearanceFeatureGet(AppearanceType type)
        {
            // first off, are going to use features typical to the location?
            // 1/3 chance of typical features

            var rndLoc = _rnd.Next(0, 3);
            if (rndLoc.Equals(2))
            {
                var locSelect = Npc.Location.AppearanceFeatureModels.Where(x => x.AppearanceType.Equals(type) && x.Genders.Contains(Npc.Gender.ToString())).ToList();
                if (locSelect.Any())
                {
                    var rndLocSelect = _rnd.Next(0, locSelect.Count());
                    return locSelect[rndLocSelect];
                }
            }

            // if we are here, then no regional feature was found, so we grab a radnom one...

            var avail = _rndHelper.Availability();
            var featuresPoss = _context.AppearanceFeatures.Where(x => x.AppearanceType == type);
            featuresPoss = featuresPoss.Where(x => x.Genders.Contains(Npc.Gender.ToString()));
            if (!featuresPoss.Any(x => x.Availability == avail))
            {
                avail = Availability.Common;
            }
            featuresPoss = featuresPoss.Where(x => x.Availability == avail);
            var featuresList = featuresPoss.Where(x => x.Races.Contains(Npc.Race.ToString())).ToList();
            var rnd = _rnd.Next(0, featuresList.Count());
            return featuresList[rnd];
        }

        private void GetDemeanour()
        {
            var demList = _context.Demeanours.ToList();
            var demRnd = _rnd.Next(0, demList.Count());
            var dem = demList[demRnd];
            Npc.Demeanour = new List<DemeanourModel> { dem };
        }

        private void GetNpcRndClass()
        {
            var clsRnd = _rnd.Next(0, _context.Classes.Count());
            var cls = _context.Classes.ToList()[clsRnd];
            Npc.Class = cls;
        }

        private void GetNpcClass()
        {
            if (Npc.Para.ClassName.IsNullOrEmpty())
            {
                GetNpcRndClass();
            }
            else
            {
                Npc.Class = _context.Classes.ToList().FirstOrDefault(x => x.Name.Equals(Npc.Para.ClassName));
            }
        }

        private void GetNpcRace()
        {
            if (Npc.Para.RaceName.IsNullOrEmpty())
            {
                // first, seed it to be 50% human
                var random = new Random(Environment.TickCount);
                var test = random.Next(1, 2);
                if (test == 1)
                {
                    Npc.Para.RaceName = "Human";
                    Npc.RaceModel = _context.Races.ToList().FirstOrDefault(x => x.Name.Equals(Npc.Para.RaceName));
                    Debug.Assert(Npc.RaceModel != null, "Npc.RaceModel != null");
                    Npc.Race = Npc.RaceModel.Race;
                }
                else
                {
                    var races = _context.Races.ToList();
                    test = random.Next(races.Count());
                    Npc.RaceModel = races[test];
                    Npc.Race = Npc.RaceModel.Race;
                }
            }
            else
            {
                Npc.RaceModel = _context.Races.ToList().FirstOrDefault(x => x.Name.Equals(Npc.Para.RaceName));
                Debug.Assert(Npc.RaceModel != null, "Npc.RaceModel != null");
                Npc.Race = Npc.RaceModel.Race;
            }
        }

        private void SplitClassProficiencies()
        {
            Npc.ClassSaves = Npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Save).ToList();
            Npc.ClassSkills = Npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Skill).ToList();
            Npc.ClassTools = Npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Tool).ToList();
        }

        private void GetCustomProficiencies()
        {
            // so here, we will randomly decide whether to limit proficiencies to location/race, ro go full random
            // 50/50 split

            var rnd = _rnd.Next(0, 2);

            if (rnd.Equals(1))
            {
                Npc.CustomProficiencies = Npc.Location.CulturalProficiencies;
            }
            else
            {
                var profPoss = _context.Proficiencies.ToList().Where(p => !Npc.Class.Proficiencies.Contains(p) && p.Type != ProficiencyTypes.Save).ToList();
                var profRnd = _rnd.Next(0, profPoss.Count());
                var profCustom = profPoss.ToList()[profRnd];
                Npc.CustomProficiencies = new List<ProficiencyModel> {profCustom};
            }
        }

        private void AddCustomProficiency()
        {
            var profPoss = _context.Proficiencies.ToList().Where(p => !Npc.Class.Proficiencies.Contains(p) && !Npc.CustomProficiencies.Contains(p) && p.Type != ProficiencyTypes.Save).ToList();
            var profRnd = _rnd.Next(0, profPoss.Count());
            var profCustom = profPoss.ToList()[profRnd];
            Npc.CustomProficiencies.Add(profCustom);
        }

        private void AddCustomProficiency(Abilities abil)
        {
            var profPoss = _context.Proficiencies.ToList().Where(p => !Npc.Class.Proficiencies.Contains(p) && !Npc.CustomProficiencies.Contains(p) && p.Type != ProficiencyTypes.Save && p.Ability.Equals(abil)).ToList();
            var profRnd = _rnd.Next(0, profPoss.Count());
            var profCustom = profPoss.ToList()[profRnd];
            Npc.CustomProficiencies.Add(profCustom);
        }

        private void AddSpecificProficiency( Proficiencies prof)
        {
            if (!Npc.Class.Proficiencies.Any(p => p.Id.Equals(prof)) && !Npc.CustomProficiencies.Any(r => r.Id.Equals(prof)))
            {
                // var profMod = _context.Proficiencies.Where(p => p.ProficiencyId.Equals(prof)).ToList().FirstOrDefault(); ;

                ProficiencyModel profMod = null;

                foreach (var pr in _context.Proficiencies)
                {
                    if (pr.Id.ToString().Equals(prof.ToString()))
                    {
                        profMod = pr;
                        break;
                    }
                }

                if (profMod != null)
                {
                    if (profMod.Type.Equals(ProficiencyTypes.Save))
                    {                        
                        Npc.ClassSaves.Add(profMod);
                    }
                    else
                    {
                        Npc.CustomProficiencies.Add(profMod);
                    }
                }
            }
        }

        private void AddCulturalWeaponProficiency()
        {
            // we're going to give everyone a 1/3 chance at one of their cultural weapons, because why not...
            var rnd = _rnd.Next(0, 3);

            if (rnd > 1)
            {
                var classAttackNames = Npc.Class.Attacks.Select(y => y.Name).ToList();
                var attacks = Npc.Location.CulturalWeapons.Where(x => !classAttackNames.Contains(x.Name)).ToList();

                var select = _rnd.Next(0, attacks.Count());

                Npc.Class.Attacks.Add(attacks[select]);
            }
        }

        private void GetClassAbilities()
        {
            Npc.ClassAbilities = new List<ClassAbilityModel>();

            foreach (var abi in Npc.Class.ClassAbilities)
            {
                abi.Description = abi.Description.LevelBasedReplace(Npc.Class.Level);
                Npc.ClassAbilities.Add(abi);
            }
        }

        private void GetQuirks()
        {
            var qrkList = _context.Quirks.ToList();
            var qrkRnd = _rnd.Next(0, qrkList.Count());
            var qrk = qrkList[qrkRnd];
            Npc.Quirks = new List<QuirkModel> { qrk };
        }

        private void GetAge()
        {
            var age = _rnd.Next(100);

            if (age > 97)
            {
                Npc.Age = Age.Ancient;
            }
            else if (age > 85)
            {
                Npc.Age = Age.Old;
            }
            else if (age > 60)
            {
                Npc.Age = Age.MiddleAged;
            }
            else if (age > 35)
            {
                Npc.Age = Age.Adult;
            }
            else if (age > 8)
            {
                Npc.Age = Age.Young;
            }
            else
            {
                Npc.Age = Age.Child;
            }
        }

        private void GetNameAndGender()
        {
            Npc.Gender = _rnd.Next(2) == 1 ? Gender.Male : Gender.Female;

            List<string> namesPoss;
            switch (Npc.Gender)
            {
                case Gender.Female:
                    namesPoss = Names.FemaleNames();
                    break;
                default:
                    namesPoss = Names.MaleNames();
                    break;
            }

            Npc.Name = namesPoss.Skip(_rnd.Next(0, namesPoss.Count())).Take(1).FirstOrDefault();
        }

        public void NpcParamsProcess()
        {
            ExperienceLevelProcess();
            StatBuffsProcess();
            if (Npc.RaceModel != null)
            {
                RaceProcess();
            }
            AbilityCeilingEnforce();
            ParamProcessWrapUp();
        }

        private void ExperienceLevelProcess()
        {
            switch (Npc.Para.ExperienceLevel)
            {
                case ExperienceLevel.Novice:
                    LevelTweak(-4);
                    break;
                case ExperienceLevel.Apprentice:
                    LevelTweak(-2);
                    break;
                case ExperienceLevel.Journeyman: 
                    break;
                case ExperienceLevel.Expert:
                    LevelTweak(2);
                    break;
                case ExperienceLevel.Master:
                    LevelTweak(4);
                    RandomAbilityTweak(2);
                    break;
            }
        }

        private void StatBuffsProcess()
        {
            if (Npc.Para.MoreStr)
            {
                Npc.Class.Strength += 4;
                AddSpecificProficiency(Proficiencies.StrengthSave);
                AddCustomProficiency(Abilities.Strength);
            }
            if (Npc.Para.MoreDex)
            {
                Npc.Class.Dexterity += 4;
                AddSpecificProficiency(Proficiencies.DexteritySave);
                AddCustomProficiency(Abilities.Dexterity);
            }
            if (Npc.Para.MoreCon)
            {
                Npc.Class.Constitution += 4;
                AddSpecificProficiency(Proficiencies.ConstitutionSave);
                Npc.Class.HitPoints = Npc.Class.HitPointsMaxGet();
            }
            if (Npc.Para.MoreInt)
            {
                Npc.Class.Intelligence += 4;
                AddSpecificProficiency(Proficiencies.IntelligenceSave);
                AddCustomProficiency(Abilities.Intelligence);
            }
            if (Npc.Para.MoreWis)
            {
                Npc.Class.Wisdom += 4;
                AddSpecificProficiency(Proficiencies.WisdomSave);
                AddCustomProficiency(Abilities.Wisdom);
            }
            if (Npc.Para.MoreCha)
            {
                Npc.Class.Charisma += 4;
                AddSpecificProficiency(Proficiencies.CharismaSave);
                AddCustomProficiency(Abilities.Charisma);
            }
        }

        private void LevelTweak( int tweak)
        {
            var tweakedLevel = Npc.Class.Level + tweak;

            if (tweakedLevel < 1)
            {
                Npc.Class.Level = 1;
                RandomAbilityTweak(-2);
            }
            else
            {
                Npc.Class.Level = tweakedLevel;
            }
        }

        private void RandomAbilityTweak( int change)
        {
            var abil = EnumHelper.RandomEnumValue<Abilities>().ToString();
            var type = Npc.Class.GetType();
            var properties = type.GetProperties();

            var prop = properties.FirstOrDefault(p => p.Name.Equals(abil));
            if (prop != null)
            {
                var val = (int)prop.GetValue(Npc.Class, null);
                prop.SetValue(Npc.Class, val + change);
            }
        }

        private void RaceProcess()
        {
            Npc.Class.Strength += Npc.RaceModel.StrengthMod;
            Npc.Class.Dexterity += Npc.RaceModel.DexterityMod;
            Npc.Class.Constitution += Npc.RaceModel.ConstitutionMod;
            Npc.Class.Intelligence += Npc.RaceModel.IntelligenceMod;
            Npc.Class.Wisdom += Npc.RaceModel.WisdomMod;
            Npc.Class.Charisma += Npc.RaceModel.CharismaMod;

            if (Npc.RaceModel.RaceAbilities.Any(x => x.Name.Equals(StringConstants.ExtraProf)))
            {
                var extraProf = Npc.RaceModel.RaceAbilities.FirstOrDefault(x => x.Name.Equals(StringConstants.ExtraProf));
                Npc.RaceModel.RaceAbilities.Remove(extraProf);
                AddCustomProficiency();
            }
        }

        private void AbilityCeilingEnforce()
        {
            Npc.Class.Strength = Npc.Class.Strength > 20 ? 20 : Npc.Class.Strength;
            Npc.Class.Dexterity = Npc.Class.Dexterity > 20 ? 20 : Npc.Class.Dexterity;
            Npc.Class.Constitution = Npc.Class.Constitution > 20 ? 20 : Npc.Class.Constitution;
            Npc.Class.Intelligence = Npc.Class.Intelligence > 20 ? 20 : Npc.Class.Intelligence;
            Npc.Class.Wisdom = Npc.Class.Wisdom > 20 ? 20 : Npc.Class.Wisdom;
            Npc.Class.Charisma = Npc.Class.Charisma > 20 ? 20 : Npc.Class.Charisma;
        }

        private void ParamProcessWrapUp()
        {
            if (Npc.Para.MoreCon)
            {
                Npc.Class.HitPoints = Npc.Class.HitPointsMaxGet();
            }
            else
            {
                Npc.Class.HitPoints = Npc.Class.HitPointsAverageGet();
            }
        }

        public void AttackRecalculate()
        {
            foreach (var at in Npc.Class.Attacks)
            {
                at.ToHit = LevelConstants.ProficiencyBonus(Npc.Class.Level) + Npc.Class.AbilityModifierGet(at.Ability);                
            }
        }
    }
}