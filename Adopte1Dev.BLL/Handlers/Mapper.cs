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
        // DAL => BLL
        // Transformer les Dev de mon DAL en Dev de mon BLL
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
                (int.TryParse(entity.DevCategPrincipal, out int id))?(int?)id : null
                );
        }

        // Transformer les Categ de mon DAL en Categ de mon BLL
        public static CategoriesBLL ToBLL(this D.Categories entity) // Ajouter une dépendance pour lier avec DAL
        {
            if (entity == null) return null;
            return new CategoriesBLL(
                entity.idCategory,
                entity.CategLabel
                );
        }
        public static ClientBLL ToBLL(this D.Client entity) // Ajouter une dépendance pour lier avec DAL
        {
            if (entity == null) return null;
            return new ClientBLL(
                entity.idClient,
                entity.CliName,
                entity.CliFirstName,
                entity.CliMail,
                entity.CliCompany,
                entity.CliLogin,
                entity.CliPassword
                );
        }

        // BLL => DAL
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
                DevCategPrincipal = entity.DevCategPrincipal.ToString()
            };
        }
        //public static D.Categories ToDAL(this CategoriesBLL entity)
        //{
        //    if (entity == null) return null;
        //    return new D.Categories
        //    {
        //        entity.idCategory,
        //        entity.CategLabel
        //    };
        //}

        public static D.Client ToDAL(this ClientBLL entity) // Ajouter une dépendance pour lier avec DAL
        {
            if (entity == null) return null;
            return new D.Client
            {

                idClient = entity.idClient,
                CliName = entity.CliName,
                CliFirstName = entity.CliFirstName,
                CliMail = entity.CliMail,
                CliCompany = entity.CliCompany,
                CliLogin = entity.CliLogin,
                CliPassword = entity.CliPassword
            };
        }
    }
}
