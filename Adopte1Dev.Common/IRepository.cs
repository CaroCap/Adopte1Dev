using System;
using System.Collections.Generic;
using System.Text;

namespace Adopte1Dev.Common
{
    public interface IRepository<TEntity, TId> : IGetRepository<TEntity, TId>
    {
        TId Insert(TEntity entity);
        void Delete(TId id);
        void Update(TId id, TEntity entity);
    }
}
