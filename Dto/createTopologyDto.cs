using System.ComponentModel.DataAnnotations;

namespace topology_api.modules
{
    public class CreateTopologyDto
    {
        [Required]
        public string id { get; set; }
        
        [Required]
        public List<Dictionary<string, dynamic>> components { get; set; }
    }
}