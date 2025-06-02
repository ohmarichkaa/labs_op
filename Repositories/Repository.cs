using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6_op.Models;

namespace lab6_op.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDataStorage<T> _storage;

        public Repository(IDataStorage<T> storage)
        {
            _storage = storage;
        }

        public void Add(T entity)
        {
            _storage.Add(entity);
            _storage.Save();
        }

        public void Update(T entity)
        {
            _storage.Update(entity);
            _storage.Save();
        }

        public void Remove(T entity)
        {
            _storage.Delete(entity.ID);
            _storage.Save();
        }

        public T? GetById(int id)
        {
            return _storage.GetById(id);
        }

        public List<T> GetAll() => _storage.GetAll();
    }
}
