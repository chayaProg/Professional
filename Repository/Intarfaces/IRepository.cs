using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Intarfaces
{
    public interface IRepository<T> where T : class
    {
        public Task Add(T item);
        public Task Update(int id, T item);
        public Task Delete(int id);
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
    }
}
