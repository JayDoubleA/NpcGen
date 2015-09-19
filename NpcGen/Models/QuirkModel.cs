using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models
{
    public class QuirkModel
    {
        [Key]
        public int QuirkId { get; set; }

        public string Description { get; set; }
    }
}