using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public AppearanceFeatureModel() { }

        public AppearanceFeatureModel(string name, AppearanceType type, string description = "", Availability availability = Availability.Common, List<Race> races = null)
        {
            Name = name;
            AppearanceType = type;
            Description = description.NotNullOrEmpty() ? description : name;
            Availability = availability;
            
            var raceEnums = races ?? AllRaces;
            Races = string.Join("|", raceEnums);
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