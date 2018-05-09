using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity item);
        IQueryable<TEntity> Get();
        IEnumerable<TaskVM> GetByCategoryAndName(string category, string name, int skip, int take);
        void Remove(TEntity item);
        void Update(TEntity item);
        int Count();
    }
}
