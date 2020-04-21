using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBWORK.WEB3.Repositories
{
    public interface IRepository<TEntity> 
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);

        void Delete(int id);


    }
}
