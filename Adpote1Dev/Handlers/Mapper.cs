using Adopte1Dev.BLL.Entities;
using Adpote1Dev.Models;

namespace Adpote1Dev.Handlers
{
    public static class Mapper     // On ajoute static pour le Mapper et on mettra toutes les méthode de transformation en public static
    {
        public static DeveloperListItem ToListItem(this DeveloperBLL entity) // De BLL vers ASP
        {
            if (entity == null) return null;
            return new DeveloperListItem
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevPicture = entity.DevPicture,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }
    }
}
