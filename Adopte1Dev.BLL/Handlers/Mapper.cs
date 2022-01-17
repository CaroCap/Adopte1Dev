using Adopte1Dev.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
// On peut utiliser des alias pour nous faciliter le nom ==> using NomAlias = chemin de l'alias;
using D = Adopte1Dev.DAL.Entities;

namespace Adopte1Dev.BLL.Handlers
{
    public static class Mapper
    {
        // Transformer les Cinemas de mon DAL en Cinema de mon BLL
        public static DeveloperBLL ToBLL(this D.Developer entity) // Ajouter une dépendance pour lier avec DAL
        {
            if (entity == null) return null;
            return new DeveloperBLL(
                entity.idDev, 
                entity.DevName, 
                entity.DevFirstName, 
                entity.DevBirthDate, 
                entity.DevPicture, 
                entity.DevHourCost, 
                entity.DevDayCost, 
                entity.DevMonthCost, 
                entity.DevMail, 
                entity.DevCategPrincipal
                );
        }

        public static D.Developer ToDAL(this DeveloperBLL entity)
        {
            if (entity == null) return null;
            return new D.Developer
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate = entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevHourCost = entity.DevHourCost,
                DevDayCost = entity.DevDayCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }
    }
}
