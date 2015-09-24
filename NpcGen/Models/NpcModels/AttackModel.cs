using NpcGen.Constants;
using NpcGen.Enums;
using NpcGen.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NpcGen.Models.NpcModels
{
    public class AttackModel
    {
        [Key]
        public int AttackId { get; set; }

        public string Name { get; set; }
        public int ToHit { get; set; }
        public string Damage { get; set; }
        public int Range { get; set; }
        public Abilities Ability { get; set; }
        public string Special { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }

        public AttackModel()
        {

        }

        public AttackModel(string name, ClassModel cls, Abilities ability, string damageDice, int range = 5, string special = "")
        {
            Name = name;
            Range = range;
            Special = special;
            Ability = ability;

            var abilityMod = cls.AbilityModifierGet(Ability);
            ToHit = abilityMod + LevelConstants.ProficiencyBonus(cls.Level);

            Damage = damageDice;            
        }
    }    
}