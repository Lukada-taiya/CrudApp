using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Application
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> Add(FormattableString sqlQuery);
        Task<IEnumerable<TEntity>> GetAllAsync(string query);

        Task<TEntity> Get(FormattableString query);
        Task<int> Update(FormattableString sqlQuery);

        Task<int> Delete(FormattableString query);
    }
}
