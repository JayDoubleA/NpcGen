﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.Models.NpcModels
{
    public class NpcModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Age Age { get; set; }

        public ClassModel Class { get; set; }

        public AppearanceModel Appearance { get; set; }
        public virtual ICollection<ProficiencyModel> ClassSkills { get; set; }
        public virtual ICollection<ProficiencyModel> ClassSaves { get; set; }
        public virtual ICollection<ProficiencyModel> ClassTools { get; set; }
        public virtual ICollection<ProficiencyModel> CustomProficiencies { get; set; }
        public virtual ICollection<QuirkModel> Quirks { get; set; }
        public virtual ICollection<DemeanourModel> Demeanour { get; set; }

        public string Pers(bool hasCapital = false)
        {
            if (hasCapital)
            {
                return Gender.Equals(Gender.Female) ? "She" : "He";
            }

            return Gender.Equals(Gender.Female) ? "she" : "he";
        }

        public string Poss(bool hasCapital = false)
        {
            if (hasCapital)
            {
                return Gender.Equals(Gender.Female) ? "Her" : "His";
            }

            return Gender.Equals(Gender.Female) ? "her" : "his";
        }
    }
}