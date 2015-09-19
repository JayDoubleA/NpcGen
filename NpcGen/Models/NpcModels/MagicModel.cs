using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class MagicModel
    {
        [Key]
        public string MagicName { get; set; }

        public  virtual ICollection<SpellLevelModel> SpellLevels { get; set; }
    }

    public class SpellLevelModel
    {
        [Key]
        public int SpellLevelId { get; set; }

        public  virtual ICollection<SpellModel> Spells { get; set; }
        public int Slots { get; set; }
    }

    public class SpellModel
    {
        [Key]
        public int SpellId {get; set; }

        public string Name { get; set; }
        public string Ref { get; set; }
        public string Save {get; set; }
        public bool IsAttack { get; set; }
        public bool HasVerbal { get; set; }
        public bool HasMaterial { get; set; }
        public bool HasSomatic { get; set; }
    }
}