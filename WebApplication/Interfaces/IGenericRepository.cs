using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int Id);
    }
}
