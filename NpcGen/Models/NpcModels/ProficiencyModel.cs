using NpcGen.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class ProficiencyModel
    {
        public string Name { get; set; }
        [Key]
        public Proficiencies ProficiencyId { get; set; }
        public ProficiencyTypes Type { get; set; }
        public Abilities Ability { get; set; }

        public virtual ICollection<ClassModel> Classes { get; set; }
        public virtual ICollection<RaceModel> Races { get; set; }
    }
}