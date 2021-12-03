using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceAbstracts
{
    public interface IBaseService<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        public Task UpdateAsync(int id, T entity);
        public Task<T> CreateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
