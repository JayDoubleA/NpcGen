using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels.NpcModels
{
    public class QuirkModel
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}