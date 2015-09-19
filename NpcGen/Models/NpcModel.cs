using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models
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
        public  virtual ICollection<ProficiencyModel> CustomProficiencies { get; set; }
        public  virtual ICollection<QuirkModel> Quirks { get; set; }
    }
}