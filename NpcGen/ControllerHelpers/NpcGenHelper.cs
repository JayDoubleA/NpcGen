using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NpcGen.Constants;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

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

        public NpcModel RandomNpcGet()
        {
            var npc = new NpcModel();

            GetNpcClass(npc);
            SplitClassProficiencies(npc);
            GetAge(npc);
            GetCustomProficiencies(npc);
            GetNameAndGender(npc);
            GetQuirks(npc);
            GetDemeanour(npc);
            GetAppearance(npc);

            return npc;
        }

        private void GetAppearance(NpcModel npc)
        {
            var ftrList = _context.GeneralAppearances.ToList();

            var eyes = ftrList.Where(f => f.Feature.IndexOf("eyes", StringComparison.OrdinalIgnoreCase) != -1);
            var eyesRnd = _rnd.Next(eyes.Count());
            var hair = ftrList.Where(f => f.Feature.IndexOf("hair", StringComparison.OrdinalIgnoreCase) != -1);
            var hairRnd = _rnd.Next(hair.Count());
            var other = ftrList.Except(eyes).Except(hair).ToList();
            var otherRnd = _rnd.Next(other.Count());
            npc.Appearance = new AppearanceModel { GeneralAppearance = new List<GeneralAppearanceModel> { eyes.ElementAt(eyesRnd), hair.ElementAt(hairRnd), other.ElementAt(otherRnd) } };
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
    }
}