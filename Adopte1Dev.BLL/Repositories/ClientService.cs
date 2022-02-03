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
    public class ClientService : IClientRepository<ClientBLL>
    {
        private readonly IClientRepository<D.Client> _repository;

        public ClientService(IClientRepository<D.Client> repository)
        {
            _repository = repository;
        }
        public int checkPassword(string login, string password)
        {
            return _repository.checkPassword(login, password);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientBLL> Get()
        {
            // Vu que c'est une liste d'objet IEnumerable, il faut utiliser LinQ (using) avec le .Select pour qu'il transforme chaque Developer.
            return _repository.Get().Select(r => r.ToBLL());
        }

        public ClientBLL Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(ClientBLL entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, ClientBLL entity)
        {
            throw new NotImplementedException();
        }
    }
}
