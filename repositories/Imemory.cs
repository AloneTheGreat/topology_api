using topology_api.modules;

namespace topology_api.repositories
{
    public interface Imemory
    {
        Task<Topology> Get_Topology_Async(string id);
        Task<IEnumerable<Topology>> Get_Topologies_Async();
        Task Create_Topology_Async(Topology topology);
        Task Delete_Topology_Async(string id);
    }

}