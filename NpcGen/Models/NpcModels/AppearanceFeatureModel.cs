using System;
using System.Collections.Generic;
using System.Linq;
using NpcGen.Enums;
using NpcGen.Extensions;

namespace NpcGen.Models.NpcModels
{
    public class AppearanceFeatureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppearanceType AppearanceType { get; set; }
        public string Description { get; set; }
        public string Races { get; set; }
        public Availability Availability { get; set; }
        public string Genders { get; set; }

        public AppearanceFeatureModel() { }

        public AppearanceFeatureModel(string name, AppearanceType type, string description = "", Availability availability = Availability.Common, List<Race> races = null, List<Gender> genders = null)
        {
            Name = name;
            AppearanceType = type;
            Description = description.NotNullOrEmpty() ? description : name;
            Availability = availability;
            
            var raceEnums = races ?? AllRaces;
            Races = string.Join("|", raceEnums);

            var genderEnums = genders ?? new List<Gender> {Gender.Female, Gender.Male};
            Genders = string.Join("|", genderEnums);
        }

        private static List<Race> AllRaces
        {
            get
            {
                return Enum.GetValues(typeof (Race)).Cast<Race>().ToList();
            }
        }
    }
}