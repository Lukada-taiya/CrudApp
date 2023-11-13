using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application;
using CrudApp.Infrastructure;
using Microsoft.EntityFrameworkCore; 

namespace CrudApp.Infrastructure.Persistence
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BrandContext _brandContext;

        public GenericRepository(BrandContext brandContext)
        {
            _brandContext = brandContext;
        }

        public async Task<int> Add(FormattableString sqlQuery)
        {
            var result = _brandContext.Database.ExecuteSqlInterpolated(sqlQuery);
            await _brandContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(FormattableString query)
        {
            var result = _brandContext.Database.ExecuteSqlInterpolated(query);
            await _brandContext.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            return await _brandContext.Set<TEntity>().FromSqlRaw(query).ToListAsync();
        }

        public async Task<int> Update(FormattableString sqlQuery)
        {
            var result = _brandContext.Database.ExecuteSqlInterpolated(sqlQuery);
            await _brandContext.SaveChangesAsync();
            return result;
        }

    }
}
