using System.ComponentModel;
using NpcGen.Models.NpcModels;

namespace NpcGen.Models
{
    public class ImportModel
    {
        public string Message { get; set; }
        [DisplayName("Paste your CSV text and select an importer to run.")]
        public string Csv { get; set; }
        public ImportType ImportType { get; set; }
    }
}