using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NpcGen.Enums;

namespace NpcGen.Models.NpcModels
{
    public class LocationModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public virtual ICollection<AppearanceFeatureModel> AppearanceFeatureModels { get; set; }
        public virtual ICollection<RaceModel> MajorRaces { get; set; }
        public virtual ICollection<RaceModel> AbsentRaces { get; set; }
        public virtual ICollection<LocationModel> LocationCloseTies { get; set; }
        public virtual ICollection<LocationModel> LocationDistantTies { get; set; }
        public virtual ICollection<AttackModel> CulturalWeapons { get; set; }
        public virtual ICollection<ProficiencyModel> CulturalProficiencies { get; set; }
        public string NamesMale { get; set; }
        public string NamesFemale { get; set; }
        public string NamesFamily { get; set; }
        public Integration Integration { get; set; }

        public LocationModel() { }

        public LocationModel(string name, string description)
        {
            Name = name;
            DescriptionShort = description;
        }
    }
}