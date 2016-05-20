using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class AttackPropertyModel
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<AttackModel> Attacks { get; set; }
        public string Name { get; set; }

        public AttackPropertyModel() { }

        public AttackPropertyModel(string name)
        {
            Name = name;
        }
    }
}