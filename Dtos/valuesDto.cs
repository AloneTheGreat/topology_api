using System.ComponentModel.DataAnnotations;
using topology_api.modules;

namespace topology_api.Dtos
{
    public class ValuesDto
    {
        [Required]
        public double @default { get; set; }
        [Required]
        public double min { get; set; }
        [Required]
        public double max { get; set; }
    }
}