using Adopte1Dev.BLL.Entities;
using Adopte1Dev.BLL.Handlers;
using Adopte1Dev.Common;
using Adopte1Dev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D = Adopte1Dev.DAL.Entities;


namespace Adopte1Dev.BLL.Repositories
{
    public class CategoriesService : ICategoriesRepository<CategoriesBLL>
    {
        private readonly ICategoriesRepository<D.Categories> _repository;

        public CategoriesService(ICategoriesRepository<Categories> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriesBLL> Get()
        {
            // Vu que c'est une liste d'objet IEnumerable, il faut utiliser LinQ (using) avec le .Select pour qu'il transforme chaque Developer.
            return _repository.Get().Select(r => r.ToBLL());
        }

        public CategoriesBLL Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(CategoriesBLL entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CategoriesBLL entity)
        {
            throw new NotImplementedException();
        }
    }
}
