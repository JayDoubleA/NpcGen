using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpcGen.Models.NpcModels
{
    public class ClassModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int HitDieType { get; set; }
        public int Level { get; set; }
        public int ProficencyBonus { get; set; }

        public  virtual ICollection<AttackModel> Attacks { get; set; }
        public MagicModel Magic { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int HitPoints { get; set; }
        public int Movement { get; set; }
        public int BaseArmourClass { get; set; }

        public  virtual ICollection<ProficiencyModel> Proficiencies { get; set; }
        public  virtual ICollection<ProficiencyModel> Expertises { get; set; }

        public virtual ICollection<ClassAbilityModel> ClassAbilities { get; set; }

        public string Possessions { get; set; }       

        public int Xp { get; set; }
    }
}