using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NpcGen.Models.NpcModels
{
    public class AppearanceModel
    {
        [Key]
        public int AppearanceId { get; set; }

        public  virtual ICollection<GeneralAppearanceModel> GeneralAppearance { get; set; }
        public  virtual ICollection<FaceModel> Face { get; set; }
        public Age Age { get; set; }
    }

    public class GeneralAppearanceModel
    {
        [Key]
        public int GeneralAppearanceId { get; set; }

        public string Feature { get; set; }
    }

    public class FaceModel
    {
        [Key]
        public int FaceId { get; set; }

        public string FaceFeature { get; set; }
    }
}