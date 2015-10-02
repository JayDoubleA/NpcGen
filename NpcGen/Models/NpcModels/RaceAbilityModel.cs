using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class RaceAbilityModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RaceModel> Races { get; set; }

        public RaceAbilityModel()
        {
            
        }

        public RaceAbilityModel(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}