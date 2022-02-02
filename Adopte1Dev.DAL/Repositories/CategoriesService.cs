using Adopte1Dev.Common;
using Adopte1Dev.DAL.Entities;
using Adopte1Dev.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Adopte1Dev.DAL.Repositories
{
    public class CategoriesService : ServiceBase, ICategoriesRepository<Categories>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categories> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idCategory], [CategLabel] FROM [Categories]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // Yield Return permet de retourner la ligne jusqu'à ce qu'il n'y ait plus rien a lire.
                    // Un return normal casse la fonction qui ne retourne du coup qu'un seul événement
                    while (reader.Read()) yield return Mapper.ToCategories(reader);
                }
            }
        }

        public Categories Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idCategory], [CategLabel] FROM [Categories] WHERE [idCategory] = @idCategory";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idCategory", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToCategories(reader);
                    return null;
                }
            }
        }

        public int Insert(Categories entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
