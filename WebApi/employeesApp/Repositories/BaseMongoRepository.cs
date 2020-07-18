// using System.Threading.Tasks;
// using MongoDB.Driver;
//
// namespace employeesApp.Repositories
// {
//     public class BaseMongoRepository<TEntity>//: IReadRepository<TEntity>
//         //where TEntity : IReadEntity
//     {
//         protected const int DuplicateCode = 11000;
//         protected readonly IMongoDatabase _mongoDatabase;
//
//         public BaseMongoRepository(IMongoDatabase mongoDatabase)
//         {
//             _mongoDatabase = mongoDatabase;
//         }
//
//         protected string CollectionName => typeof(TEntity).Name;
//
//         public async Task InsertAsync(TEntity entity)
//         {
//             try
//             {
//                 await _mongoDatabase.GetCollection<TEntity>(CollectionName)
//                                     .InsertOneAsync(entity);
//             }
//             catch (MongoWriteException ex)
//             {
//                 if (ex.WriteError.Code == DuplicateCode)
//                 {
//               //      throw new DuplicateException();
//                 }
//
//               //  throw new FailRepositoryException(ex.Message);
//             }
//             catch (MongoException ex)
//             {
//               //  throw new FailRepositoryException(ex.Message);
//             }
//         }
//
//         public async Task UpdateAsync(TEntity entity)
//         {
//             try
//             {
//                 var result = await _mongoDatabase.GetCollection<TEntity>(CollectionName)
//                                                  .ReplaceOneAsync(x => x._id == entity._id, entity);
//
//                 if (result.MatchedCount != 1)
//                 {
//                  //   throw new MissingEntityException(entity._id);
//                 }
//             }
//             catch (MongoException ex)
//             {
//                // throw new FailRepositoryException(ex.Message);
//             }
//         }
//
//         public async Task<TEntity> GetByIdAsync(string id) =>
//             await _mongoDatabase.GetCollection<TEntity>(CollectionName)
//                                 .Find(x => x._id == id)
//                                 .FirstOrDefaultAsync();
//     }
// }