using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models
{
    public class ProficiencyModel
    {
        public string Name { get; set; }
        [Key]
        public Proficiencies ProficiencyId { get; set; }
        public ProficiencyTypes Type { get; set; }
        public Abilities Stat { get; set; }

        public  virtual ICollection<ClassModel> Classes { get; set; }
    }
}