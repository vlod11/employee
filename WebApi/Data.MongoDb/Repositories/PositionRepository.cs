using Core.PositionAggregate;
using Data.MongoDb.Repositories.Interfaces;
using MongoDB.Driver;

namespace Data.MongoDb.Repositories
{
    public class PositionRepository : BaseMongoDbRepository<Position>, IPositionRepository
    {
        public PositionRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase)
        {
        }
    }
}