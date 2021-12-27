using System.ComponentModel.DataAnnotations;
using topology_api.modules;

namespace topology_api.Dtos
{
    public class TopologyDto
    {
        [Required]
        public string id { get; set; }
        [Required]
        public List<TopologyComponentsDto> components { get; set; }
    }
}