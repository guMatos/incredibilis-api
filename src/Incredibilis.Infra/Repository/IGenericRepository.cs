using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Incredibilis.Infra.Repository
{
    public interface IGenericRepository
    {
        IQueryable<T> All<T>() where T : class, new();
        IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new();
        Task<T> Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
        Task AddAsync<T>(T document) where T : class, new();
        Task ReplaceOneAsync<T>(Expression<Func<T, bool>> expression, T document) where T : class, new();
        bool CollectionExists<T>() where T : class, new();
    }
}
