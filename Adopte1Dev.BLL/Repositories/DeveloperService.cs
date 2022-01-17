using Adopte1Dev.BLL.Entities;
using Adopte1Dev.BLL.Handlers;
using Adopte1Dev.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D = Adopte1Dev.DAL.Entities;


namespace Adopte1Dev.BLL.Repositories
{
    public class DeveloperService : IDeveloperRepository<DeveloperBLL>
    {
        private readonly IDeveloperRepository<D.Developer> _repository;

        public DeveloperService(IDeveloperRepository<D.Developer> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<DeveloperBLL> Get()
        {
            // Vu que c'est une liste d'objet IEnumerable, il faut utiliser LinQ (using) avec le .Select pour qu'il transforme chaque Cinema.
            return _repository.Get().Select(r => r.ToBLL());
        }

        public DeveloperBLL Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(DeveloperBLL entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, DeveloperBLL entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
