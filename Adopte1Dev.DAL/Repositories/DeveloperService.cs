using Adopte1Dev.Common;
using Adopte1Dev.DAL.Entities;
using Adopte1Dev.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Adopte1Dev.DAL.Repositories
{
    public class DeveloperService : ServiceBase, IDeveloperRepository<Developer>
    {
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                //Création de la commande (ordre à executer) contenant les requêtes
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Requete 
                    // @id = Sqm parameter qui permette de sécurisé les infos rentrées dans DB pour éviter hacking
                    command.CommandText = "DELETE FROM [Developer] WHERE [idDev] = @id";
                    SqlParameter p_id = new SqlParameter()
                    {
                        ParameterName = "idDev",
                        Value = id //id mis dans les parenthèses de Delete
                    };
                    //Ajouter le paramètre créé à la commande
                    command.Parameters.Add(p_id);
                    //ouvrir la commande
                    connection.Open();
                    // Executer la requête // ExecuteNonQuery() permet de récupérer le nombre de ligne qui sont retournées par ma commande
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Developer> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // Yield Return permet de retourner la ligne jusqu'à ce qu'il n'y ait plus rien a lire.
                    // Un return normal casse la fonction qui ne retourne du coup qu'un seul événement
                    while (reader.Read()) yield return Mapper.ToDeveloper(reader);
                }
            }
        }

        public Developer Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer] WHERE [idDev] = @idParam";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idParam", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToDeveloper(reader);
                    return null;
                }
            }
        }

        public int Insert(Developer entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //Output Inserted id = un ordre de récupération de données après l'insertion donc l'ID qui s'est autoincrémenté
                    command.CommandText = "INSERT INTO [Developer]([DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) " +
                        "OUTPUT [inserted].[Id] VALUES (@DevName, @DevFirstName, @DevBirthDate, @DevPicture, @DevHourCost, @DevDayCost, @DevMonthCost, @DevMail, @DevCategPrincipal)";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "DevName", Value = entity.DevName };
                    SqlParameter p_prenom = new SqlParameter { ParameterName = "DevFirstName", Value = entity.DevFirstName };
                    SqlParameter p_DevBirthDate = new SqlParameter { ParameterName = "DevBirthDate", Value = entity.DevBirthDate };
                    SqlParameter p_DevPicture = new SqlParameter { ParameterName = "DevPicture", Value = entity.DevPicture };
                    SqlParameter p_DevHourCost = new SqlParameter { ParameterName = "DevHourCost", Value = entity.DevHourCost };
                    SqlParameter p_DevDayCost = new SqlParameter { ParameterName = "DevDayCost", Value = entity.DevDayCost };
                    SqlParameter p_DevMonthCost = new SqlParameter { ParameterName = "DevMonthCost", Value = entity.DevMonthCost };
                    SqlParameter p_DevMail = new SqlParameter { ParameterName = "DevMail", Value = entity.DevMail };
                    SqlParameter p_DevCategPrincipal = new SqlParameter { ParameterName = "DevCategPrincipal", Value = entity.DevCategPrincipal };
                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_prenom);
                    command.Parameters.Add(p_DevBirthDate);
                    command.Parameters.Add(p_DevPicture);
                    command.Parameters.Add(p_DevHourCost);
                    command.Parameters.Add(p_DevDayCost);
                    command.Parameters.Add(p_DevMonthCost);
                    command.Parameters.Add(p_DevMail);
                    command.Parameters.Add(p_DevCategPrincipal);
                    connection.Open();
                    // INSERT attend un retour en int donc il faut le caster (int)
                    //Execute Scalar permet de récupérer une info précise grâce au OUTPUT
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Developer entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Developer] SET [DevName] = @DevName, [DevFirstName] = @DevFirstName, [DevBirthDate] = @DevBirthDate, [DevPicture] = @DevPicture, [DevHourCost] = @DevHourCost, [DevDayCost] = @DevDayCost, [DevMonthCost] = @DevMonthCost, [DevMail] = @DevMail, [DevCategPrincipal] = @DevCategPrincipal WHERE [idDev] = @id";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "DevName", Value = entity.DevName };
                    SqlParameter p_prenom = new SqlParameter { ParameterName = "DevFirstName", Value = entity.DevFirstName };
                    SqlParameter p_DevBirthDate = new SqlParameter { ParameterName = "DevBirthDate", Value = entity.DevBirthDate };
                    SqlParameter p_DevPicture = new SqlParameter { ParameterName = "DevPicture", Value = entity.DevPicture };
                    SqlParameter p_DevHourCost = new SqlParameter { ParameterName = "DevHourCost", Value = entity.DevHourCost };
                    SqlParameter p_DevDayCost = new SqlParameter { ParameterName = "DevDayCost", Value = entity.DevDayCost };
                    SqlParameter p_DevMonthCost = new SqlParameter { ParameterName = "DevMonthCost", Value = entity.DevMonthCost };
                    SqlParameter p_DevMail = new SqlParameter { ParameterName = "DevMail", Value = entity.DevMail };
                    SqlParameter p_DevCategPrincipal = new SqlParameter { ParameterName = "DevCategPrincipal", Value = entity.DevCategPrincipal };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idDev", Value = id };

                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_prenom);
                    command.Parameters.Add(p_DevBirthDate);
                    command.Parameters.Add(p_DevPicture);
                    command.Parameters.Add(p_DevHourCost);
                    command.Parameters.Add(p_DevDayCost);
                    command.Parameters.Add(p_DevMonthCost);
                    command.Parameters.Add(p_DevMail);
                    command.Parameters.Add(p_DevCategPrincipal);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
