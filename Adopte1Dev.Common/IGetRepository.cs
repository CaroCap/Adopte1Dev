using System;
using System.Collections.Generic;
using System.Text;

namespace Adopte1Dev.Common
{
    public interface IGetRepository<TEntity, TId>
    {
        // Pour récupérer une Liste
        IEnumerable<TEntity> Get();

        // Pour récupérer 1 seul élément
        //TEntity Get(int id);
        // Avec le Générique ça donne :
        TEntity Get(TId id);
    }
}
