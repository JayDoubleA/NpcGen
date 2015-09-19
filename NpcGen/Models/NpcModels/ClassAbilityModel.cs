using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class ClassAbilityModel
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
    }
}