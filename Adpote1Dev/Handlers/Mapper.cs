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

        public static DeveloperDetails ToDetails(this DeveloperBLL entity)
        {
            if (entity == null) return null;
            return new DeveloperDetails
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevPicture = entity.DevPicture,
                DevCategPrincipal = entity.DevCategPrincipal,
                DevBirthDate = entity.DevBirthDate,
                DevHourCost = entity.DevHourCost,
                DevDayCost = entity.DevDayCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail
            };
        }
        public static Categories ToDetails(this CategoriesBLL entity)
        {
            if (entity == null) return null;
            return new Categories
            {
                idCategory = entity.idCategory,
                CategLabel = entity.CategLabel                
            };
        }
    }
}
