using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NpcGen.Constants;
using NpcGen.DataAccess;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;
using System.Reflection;
using NpcGen.Enums;

namespace NpcGen.ControllerHelpers
{
    public class NpcGenHelper
    {
        private readonly NpcContext _context;
        private readonly Random _rnd;

        public NpcGenHelper(NpcContext context)
        {
            _context = context;
            _rnd = new Random();
        }

        public NpcModel RandomNpcGet(NpcModel para)
        {
            var npc = new NpcModel();
            npc.Para = para.Para ?? new NpcGenParamsModel();

            GetNpcClass(npc);
            SplitClassProficiencies(npc);
            GetAge(npc);
            GetCustomProficiencies(npc);
            GetNameAndGender(npc);
            GetQuirks(npc);
            GetDemeanour(npc);
            GetAppearance(npc);
            NpcParamsProcess(npc);

            return npc;
        }

        public NpcModel NpcGet(string clsName, NpcModel para)
        {
            var npc = new NpcModel();
            npc.Para = para.Para ?? new NpcGenParamsModel();

            GetNpcClass(npc, clsName);
            SplitClassProficiencies(npc);
            GetAge(npc);
            GetCustomProficiencies(npc);
            GetNameAndGender(npc);
            GetQuirks(npc);
            GetDemeanour(npc);
            GetAppearance(npc);
            NpcParamsProcess(npc);

            return npc;
        }

        private void GetAppearance(NpcModel npc)
        {
            var app = new AppearanceModel
            {
                EyeColour = EnumExtensions.ToName(EnumExtensions.Of<EyeColour>()),
                HairColor = EnumExtensions.ToName(EnumExtensions.Of<HairColour>()),
                HairStyle = EnumExtensions.ToName(EnumExtensions.Of<HairStyle>())
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
                "{0}  \"{1} eyes\" {2} {3} hair",
                app.FacialFeatures.Replace("{pos", npc.Poss()),
                app.EyeColour,
                app.HairColor,
                app.HairStyle
                );

            npc.Appearance = app;
        }

        private void GetDemeanour(NpcModel npc)
        {
            var demList = _context.Demeanours.ToList();
            var demRnd = _rnd.Next(0, demList.Count());
            var dem = demList[demRnd];
            npc.Demeanour = new List<DemeanourModel> { dem };
        }

        private void GetNpcClass(NpcModel npc)
        {
            var clsRnd = _rnd.Next(0, _context.Classes.Count());
            var cls = _context.Classes.ToList()[clsRnd];
            npc.Class = cls;
        }

        private void GetNpcClass(NpcModel npc, string clsName)
        {
            npc.Class = _context.Classes.ToList().FirstOrDefault(x => x.Name.Equals(clsName));
        }

        private void SplitClassProficiencies(NpcModel npc)
        {
            npc.ClassSaves = npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Save).ToList();
            npc.ClassSkills = npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Skill).ToList();
            npc.ClassTools = npc.Class.Proficiencies.Where(x => x.Type == ProficiencyTypes.Tool).ToList();
        }

        private void GetCustomProficiencies(NpcModel npc)
        {
            var profPoss = _context.Proficiencies.ToList().Where(p => !npc.Class.Proficiencies.Contains(p) && p.Type != ProficiencyTypes.Save);
            var profRnd = _rnd.Next(0, profPoss.Count());
            var profCustom = profPoss.ToList()[profRnd];
            npc.CustomProficiencies = new List<ProficiencyModel> { profCustom };
        }

        private void AddCustomProficiency(NpcModel npc)
        {
            var profPoss = _context.Proficiencies.ToList().Where(p => !npc.Class.Proficiencies.Contains(p) && !npc.CustomProficiencies.Contains(p) && p.Type != ProficiencyTypes.Save);
            var profRnd = _rnd.Next(0, profPoss.Count());
            var profCustom = profPoss.ToList()[profRnd];
            npc.CustomProficiencies.Add(profCustom);
        }

        private void AddCustomProficiency(NpcModel npc, Abilities abil)
        {
            var profPoss = _context.Proficiencies.ToList().Where(p => !npc.Class.Proficiencies.Contains(p) && !npc.CustomProficiencies.Contains(p) && p.Type != ProficiencyTypes.Save && p.Ability.Equals(abil));
            var profRnd = _rnd.Next(0, profPoss.Count());
            var profCustom = profPoss.ToList()[profRnd];
            npc.CustomProficiencies.Add(profCustom);
        }

        private void AddSpecificProficiency(NpcModel npc, Proficiencies prof)
        {
            if (!npc.Class.Proficiencies.Any(p => p.ProficiencyId.Equals(prof)) && !npc.CustomProficiencies.Any(r => r.ProficiencyId.Equals(prof)))
            {
                // var profMod = _context.Proficiencies.Where(p => p.ProficiencyId.Equals(prof)).ToList().FirstOrDefault(); ;

                ProficiencyModel profMod = null;

                foreach (var pr in _context.Proficiencies)
                {
                    if (pr.ProficiencyId.ToString().Equals(prof.ToString()))
                    {
                        profMod = pr;
                        break;
                    }
                }

                if (profMod != null)
                {
                    if (profMod.Type.Equals(ProficiencyTypes.Save))
                    {                        
                        npc.ClassSaves.Add(profMod);
                    }
                    else
                    {
                        npc.CustomProficiencies.Add(profMod);
                    }
                }
            }
        }

        private void GetQuirks(NpcModel npc)
        {
            var qrkList = _context.Quirks.ToList();
            var qrkRnd = _rnd.Next(0, qrkList.Count());
            var qrk = qrkList[qrkRnd];
            npc.Quirks = new List<QuirkModel> { qrk };
        }

        private void GetAge(NpcModel npc)
        {
            var age = _rnd.Next(100);

            if (age > 97)
            {
                npc.Age = Age.Ancient;
            }
            else if (age > 85)
            {
                npc.Age = Age.Old;
            }
            else if (age > 60)
            {
                npc.Age = Age.MiddleAged;
            }
            else if (age > 35)
            {
                npc.Age = Age.Adult;
            }
            else if (age > 8)
            {
                npc.Age = Age.Young;
            }
            else
            {
                npc.Age = Age.Child;
            }
        }

        private void GetNameAndGender(NpcModel npc)
        {
            npc.Gender = _rnd.Next(2) == 1 ? Gender.Male : Gender.Female;

            List<string> namesPoss;
            switch (npc.Gender)
            {
                case Gender.Female:
                    namesPoss = Names.FemaleNames();
                    break;
                default:
                    namesPoss = Names.MaleNames();
                    break;
            }

            npc.Name = namesPoss.Skip(_rnd.Next(0, namesPoss.Count())).Take(1).FirstOrDefault();
        }

       

        public void NpcParamsProcess(NpcModel npc)
        {
            ExperienceLevelProcess(npc);
            StatBuffsProcess(npc);
            AbilityCeilingEnforce(npc);
            ParamProcessWrapUp(npc);
        }

        private void ExperienceLevelProcess(NpcModel npc)
        {
            switch (npc.Para.ExperienceLevel)
            {
                case ExperienceLevel.Novice:
                    LevelTweak(npc, -4);
                    break;
                case ExperienceLevel.Apprentice:
                    LevelTweak(npc, -2);
                    break;
                case ExperienceLevel.Journeyman: 
                    break;
                case ExperienceLevel.Expert:
                    LevelTweak(npc, 2);
                    break;
                case ExperienceLevel.Master:
                    LevelTweak(npc, 4);
                    RandomAbilityTweak(npc, 2);
                    break;
            }
        }

        private void StatBuffsProcess(NpcModel npc)
        {
            if (npc.Para.MoreStr)
            {
                npc.Class.Strength += 4;
                AddSpecificProficiency(npc, Proficiencies.StrengthSave);
                AddCustomProficiency(npc, Abilities.Strength);
            }
            if (npc.Para.MoreDex)
            {
                npc.Class.Dexterity += 4;
                AddSpecificProficiency(npc, Proficiencies.DexteritySave);
                AddCustomProficiency(npc, Abilities.Dexterity);
            }
            if (npc.Para.MoreCon)
            {
                npc.Class.Constitution += 4;
                AddSpecificProficiency(npc, Proficiencies.ConstitutionSave);
                npc.Class.HitPoints = npc.Class.HitPointsMaxGet();
            }
            if (npc.Para.MoreInt)
            {
                npc.Class.Intelligence += 4;
                AddSpecificProficiency(npc, Proficiencies.IntelligenceSave);
                AddCustomProficiency(npc, Abilities.Intelligence);
            }
            if (npc.Para.MoreWis)
            {
                npc.Class.Wisdom += 4;
                AddSpecificProficiency(npc, Proficiencies.WisdomSave);
                AddCustomProficiency(npc, Abilities.Wisdom);
            }
            if (npc.Para.MoreCha)
            {
                npc.Class.Charisma += 4;
                AddSpecificProficiency(npc, Proficiencies.CharismaSave);
                AddCustomProficiency(npc, Abilities.Charisma);
            }
        }

        private void LevelTweak(NpcModel npc, int tweak)
        {
            var tweakedLevel = npc.Class.Level + tweak;

            if (tweakedLevel < 1)
            {
                npc.Class.Level = 1;
                RandomAbilityTweak(npc, -2);
            }
            else
            {
                npc.Class.Level = tweakedLevel;
            }
        }

        private void RandomAbilityTweak(NpcModel npc, int change)
        {
            var abil = EnumHelper.RandomEnumValue<Abilities>().ToString();
            var type = npc.Class.GetType();
            var properties = type.GetProperties();

            var prop = properties.FirstOrDefault(p => p.Name.Equals(abil));
            if (prop != null)
            {
                var val = (int)prop.GetValue(npc.Class, null);
                prop.SetValue(npc.Class, val + change);
            }
        }

        private void AbilityCeilingEnforce(NpcModel npc)
        {
            npc.Class.Strength = npc.Class.Strength > 20 ? 20 : npc.Class.Strength;
            npc.Class.Dexterity = npc.Class.Dexterity > 20 ? 20 : npc.Class.Dexterity;
            npc.Class.Constitution = npc.Class.Constitution > 20 ? 20 : npc.Class.Constitution;
            npc.Class.Intelligence = npc.Class.Intelligence > 20 ? 20 : npc.Class.Intelligence;
            npc.Class.Wisdom = npc.Class.Wisdom > 20 ? 20 : npc.Class.Wisdom;
            npc.Class.Charisma = npc.Class.Charisma > 20 ? 20 : npc.Class.Charisma;
        }

        private void ParamProcessWrapUp(NpcModel npc)
        {
            if (npc.Para.MoreCon)
            {
                npc.Class.HitPoints = npc.Class.HitPointsMaxGet();
            }
            else
            {
                npc.Class.HitPoints = npc.Class.HitPointsAverageGet();
            }
        }

        public void AttackRecalculate(NpcModel npc)
        {
            foreach (var at in npc.Class.Attacks)
            {
                at.ToHit = LevelConstants.ProficiencyBonus(npc.Class.Level) + npc.Class.AbilityModifierGet(at.Ability);                
            }
        }
    }
}