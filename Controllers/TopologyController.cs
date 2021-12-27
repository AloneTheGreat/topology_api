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
        public async  Task<IEnumerable<Topology>> Get_Topologies_Async()
        {
            var items = (await repository.Get_Topologies_Async())
                        .Select( item => item);
            return items;
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<Topology>> Get_Topology_Async(string id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("{id}/components")]
        public async  Task<ActionResult<List<TopologyComponents>>> Get_Topology_Components_Async(string id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.components;
        }

        [HttpGet("{id}/components/{netlist_id}")]
        public async  Task<ActionResult<List<TopologyComponents>>> Get_Topology_NetList_Components_Async(string id, string netlist_id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            var result = from s in item.components where s.netlist.ContainsValue(netlist_id) select s;
            return result.ToList();
        }

        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete_Topology_Async(string id)
        {
            var existingTopology = await repository.Get_Topology_Async(id);
            if (existingTopology is null)
            {
                return NotFound();
            }
            await repository.Delete_Topology_Async(id);
            return NoContent();
        }

        [HttpPost]
        public async  Task<ActionResult<Topology>> Create_Topology_Async(Topology topology)
        {
            await repository.Create_Topology_Async(topology: topology);
            return CreatedAtAction(actionName: nameof(Get_Topology_Async), routeValues: new {id = topology.id}, value: topology);
        }
    }
}