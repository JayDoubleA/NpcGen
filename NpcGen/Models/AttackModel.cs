using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models
{
    public class AttackModel
    {
        [Key]
        public int AttackId { get; set; }

        public string Name { get; set; }
        public int ToHit { get; set; }
        public string Damage { get; set; }
        public string Special { get; set; }
        public int Range { get; set; }
    }
}