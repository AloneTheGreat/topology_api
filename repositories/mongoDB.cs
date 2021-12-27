using MongoDB.Bson;
using MongoDB.Driver;
using topology_api.modules;

namespace topology_api.repositories
{
    public class MongoDb : Imemory
    {
        private const string DatabaseName = "Topology_Api";
        public const string CollectionName = "topologies";
        private readonly IMongoCollection<Topology> topologiesCollection;
        private readonly FilterDefinitionBuilder<Topology> filterBuilder = Builders<Topology>.Filter;
        public MongoDb(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            topologiesCollection = database.GetCollection<Topology>(CollectionName);
        }
        public async Task Create_Topology_Async(Topology topology)
        {
            await topologiesCollection.InsertOneAsync(topology);
        }

        public async  Task Delete_Topology_Async(string id)
        {
            var filter = filterBuilder.Eq(topology => topology.id, id);
            await topologiesCollection.DeleteOneAsync(filter);
        }

        public async  Task<IEnumerable<Topology>> Get_Topologies_Async()
        {
            return await topologiesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async  Task<Topology> Get_Topology_Async(string id)
        {
            var filter = filterBuilder.Eq(topology => topology.id, id);
            return await topologiesCollection.Find(filter).SingleOrDefaultAsync();
        }
    }
}