using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll(bool trackChanges);
        T Find(int id);
        void Delete(T entity);
        void Create(T entity);
        void Update(T entity);
    }
}
