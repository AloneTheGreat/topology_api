using topology_api.modules;

namespace topology_api.repositories
{
    public interface Imemory
    {
        Topology Get_Topology(string id);
        IEnumerable<Topology> Get_Topologies();
        void Create_Topology(Topology topology);
        void Delete_Topology(string id);
    }

}