using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class DemeanourModel
    {
        [Key]
        public int DemeanourId { get; set; }

        public string Description { get; set; }
    }
}