using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Data
{
    public interface IRepository<TEntity>
        where TEntity : IDocumentEntity
    {
        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(string id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}