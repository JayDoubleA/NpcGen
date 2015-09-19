using System.ComponentModel.DataAnnotations;

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
        public string Special { get; set; }
    }
}