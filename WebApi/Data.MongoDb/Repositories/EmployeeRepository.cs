using Core.EmployeeAggregate;
using Data.MongoDb.Repositories.Interfaces;
using MongoDB.Driver;

namespace Data.MongoDb.Repositories
{
    public class EmployeeRepository: BaseMongoDbRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase)
        {
        }
    }
}