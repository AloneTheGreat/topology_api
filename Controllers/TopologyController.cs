using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using topology_api.repositories;
using topology_api.modules;
using System.Linq;
using topology_api.Dtos;

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
        public IEnumerable<TopologyDto> Get_Topologies()
        {
            var items = repository.Get_Topologies().Select( item => item.AsDto());
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<TopologyDto> Get_Topology(string id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        [HttpGet("{id}/components")]
        public ActionResult<List<TopologyComponentsDto>> Get_Topology_Components(string id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto().components;
        }
        [HttpGet("{id},{netlist_id}/components")]
        public ActionResult<List<TopologyComponentsDto>> Get_Topology_NetList_Components(string id, string netlist_id)
        {
            var item = repository.Get_Topology(id);
            if (item is null)
            {
                return NotFound();
            }

            List<TopologyComponentsDto> enumerable = (List<TopologyComponentsDto>)item.AsDto().components.Where(TopologyComponentsDto => TopologyComponentsDto.netlist.Values.Equals(netlist_id));
            return enumerable;
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
        public ActionResult<TopologyDto> Create_Topology(TopologyDto topologyDto)
        {
            Topology topology = new(){
                id = topologyDto.id,
                components = new List<TopologyComponents>().Select( component => new TopologyComponents(){
                    type = component.type,
                    id = component.id,
                    value = new Values(){
                        @default = component.value.@default,
                        min = component.value.min,
                        max = component.value.max,
                    },
                    netlist = component.netlist,
                })
            };
            repository.Create_Topology(topology: topology);
            return CreatedAtAction(actionName: nameof(Get_Topology), routeValues: new {id = topology.id}, value: topology.AsDto());
        }
    }
}