
namespace Adopte1Dev.Common
{
    public interface IClientRepository<TClient> : IRepository<TClient, int>
    {
        // CONTROLER LE MOT DE PASSE => bool  // Retourner un entier avec l'id de l'user (si -1 pas trouvé le user)
        public int checkPassword(string login, string password);
        
    }
}
