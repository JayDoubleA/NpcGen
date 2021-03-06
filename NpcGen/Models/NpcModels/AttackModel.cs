﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NpcGen.Enums;

namespace NpcGen.Models.NpcModels
{
    public class AttackModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int ToHit { get; set; }
        public string Damage { get; set; }
        public Abilities Ability { get; set; }
        public DamageType DamageType { get; set; }
        public virtual ICollection<AttackPropertyModel> AttackProperties { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
        public virtual ICollection<LocationModel> Locations { get; set; }

        public AttackModel()
        {

        }

        public AttackModel(string name)
        {
            Name = name;
        }

        public AttackModel(string name, Abilities ability, string damageDice, DamageType damageType, ICollection<AttackPropertyModel> props = null, int range = 5, int rangeLong = 5)
        {
            Name = name;
            AttackProperties = props ?? new List<AttackPropertyModel>();
            Ability = ability;
            DamageType = damageType;
            Damage = damageDice;            
        }
    }
}
