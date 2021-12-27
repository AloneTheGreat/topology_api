using Microsoft.AspNetCore.Mvc;
using topology_api.repositories;
using topology_api.modules;
namespace topology_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TopologyController : ControllerBase
    {
        private readonly Imemory repository;

        public TopologyController(Imemory repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<Topology> Get_Topologies()
        {
            var items = repository.Get_Topologies().Select( item => item);
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<Topology> Get_Topology(string id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }
        [HttpGet("{id}/components")]
        public ActionResult<List<TopologyComponents>> Get_Topology_Components(string id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.components;
        }
        [HttpGet("{id},{netlist_id}/components")]
        public ActionResult<List<TopologyComponents>> Get_Topology_NetList_Components(string id, string netlist_id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }
            var result = from s in item.components where s.netlist.ContainsValue(netlist_id) select s;
            return result.ToList();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete_Topology(string id)
        {
            var existingTopology = repository.Get_Topology(id);
            if (existingTopology is null)
            {
                return NotFound();
            }
            repository.Delete_Topology(id);
            return NoContent();
        }
        [HttpPost]
        public ActionResult<Topology> Create_Topology(Topology topology)
        {
            repository.Create_Topology(topology: topology);
            return CreatedAtAction(actionName: nameof(Get_Topology), routeValues: new {id = topology.id}, value: topology);
        }
    }
}