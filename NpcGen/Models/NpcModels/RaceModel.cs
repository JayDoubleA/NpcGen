using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NpcGen.Enums;
using NpcGen.Extensions;

namespace NpcGen.Models.NpcModels
{
    public class RaceModel
    {
        [Key]
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public string Name { get; set; }
        public int StrengthMod { get; set; }
        public int DexterityMod { get; set; }
        public int ConstitutionMod { get; set; }
        public int IntelligenceMod { get; set; }
        public int WisdomMod { get; set; }
        public int CharismaMod { get; set; }
        public virtual ICollection<RaceAbilityModel> RaceAbilities { get; set; }
        public virtual ICollection<ProficiencyModel> Proficiencies { get; set; }

        public RaceModel()
        {
            
        }

        public RaceModel(Race race, int str, int dex, int con, int iq, int wis, int cha)
        {
            Race = race;
            Name = EnumExtensions.ToName(race);
            StrengthMod = str;
            DexterityMod = dex;
            ConstitutionMod = con;
            IntelligenceMod = iq;
            WisdomMod = wis;
            CharismaMod = cha;
        }
    }
}