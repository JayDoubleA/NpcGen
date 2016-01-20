using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpcGen.Models.NpcModels
{
    public class ClassAbilityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
        public int Level { get; set; }

        public ClassAbilityModel() { }

        public ClassAbilityModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public ClassAbilityModel(string name, string description, int level)
        {
            Name = name;
            Description = description;
            Level = level;
        }
    }
}