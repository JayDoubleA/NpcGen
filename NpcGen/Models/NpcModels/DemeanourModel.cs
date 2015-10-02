using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class DemeanourModel
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}