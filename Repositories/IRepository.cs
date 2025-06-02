using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6_op.Models;

namespace lab6_op.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
