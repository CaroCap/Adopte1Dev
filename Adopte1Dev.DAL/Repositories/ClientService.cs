using Adopte1Dev.Common;
using Adopte1Dev.DAL.Entities;
using Adopte1Dev.DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
//using DALEntities = Adopte1Dev.DAL.Entities;

namespace Adopte1Dev.DAL.Repositories
{
    public class ClientService : ServiceBase, IClientRepository<Client>
    {
        public void Delete(int id)
        {
            //ampoule sur SqlConnection pour Install package 'System.Data.SqlClient' puis Find and Install latest version
            //Création de la connection
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                //Création de la commande (ordre à executer) contenant les requêtes
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Requete 
                    // @id = Sqm parameter qui permette de sécurisé les infos rentrées dans DB pour éviter hacking
                    command.CommandText = "DELETE FROM [Client] WHERE [idClient] = @id";
                    SqlParameter p_id = new SqlParameter()
                    {
                        ParameterName = "idClient",
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

        public IEnumerable<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idClient], [CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword] FROM [Client]";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    // Yield Return permet de retourner la ligne jusqu'à ce qu'il n'y ait plus rien a lire.
                    // Un return normal casse la fonction qui ne retourne du coup qu'un seul événement
                    while (reader.Read()) yield return Mapper.ToClient(reader);
                }
            }
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // préféré décrire les noms de colonnes plutôt que d'utiliser * par faciliter pour gagné en efficacité pour l'application
                    // * va aller chercher toutes les colonnes à chaque ligne alors qu'on sait que le nom de la colonne n'a pas changé...
                    command.CommandText = "SELECT [idClient], [CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword] FROM [Client] WHERE [idClient] = @id";
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idClient", Value = id };
                    command.Parameters.Add(p_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) return Mapper.ToClient(reader);
                    return null;
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //Output Inserted id = un ordre de récupération de données après l'insertion donc l'ID qui s'est autoincrémenté
                    command.CommandText = "INSERT INTO [Client]([CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword]) OUTPUT [inserted].[Id] VALUES (@CliName, @CliFirstName, @CliMail, @CliLogin, @CliPassword)";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "CliName", Value = entity.CliName };
                    SqlParameter p_prenom = new SqlParameter { ParameterName = "CliFirstName", Value = entity.CliFirstName };
                    SqlParameter p_CliMail = new SqlParameter { ParameterName = "CliMail", Value = entity.CliMail };
                    SqlParameter p_CliCompany = new SqlParameter { ParameterName = "CliCompany", Value = entity.CliCompany };
                    SqlParameter p_CliLogin = new SqlParameter { ParameterName = "CliLogin", Value = entity.CliLogin };
                    SqlParameter p_CliPassword = new SqlParameter { ParameterName = "CliPassword", Value = entity.CliPassword };
                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_prenom);
                    command.Parameters.Add(p_CliMail);
                    command.Parameters.Add(p_CliCompany);
                    command.Parameters.Add(p_CliLogin);
                    command.Parameters.Add(p_CliPassword);
                    connection.Open();
                    // INSERT attend un retour en int donc il faut le caster (int)
                    //Execute Scalar permet de récupérer une info précise grâce au OUTPUT
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Client] SET [CliName] = @CliName, [CliFirstName] = @CliFirstName, [CliMail] = @CliMail, [CliCompany] = @CliCompany, [CliLogin] = @CliLogin, [CliPassword] = @CliPassword WHERE [idClient] = @id";
                    SqlParameter p_nom = new SqlParameter { ParameterName = "CliName", Value = entity.CliName };
                    SqlParameter p_prenom = new SqlParameter { ParameterName = "CliFirstName", Value = entity.CliFirstName };
                    SqlParameter p_CliMail = new SqlParameter { ParameterName = "CliMail", Value = entity.CliMail };
                    SqlParameter p_CliCompany = new SqlParameter { ParameterName = "CliCompany", Value = entity.CliCompany };
                    SqlParameter p_CliLogin = new SqlParameter { ParameterName = "CliLogin", Value = entity.CliLogin };
                    SqlParameter p_CliPassword = new SqlParameter { ParameterName = "CliPassword", Value = entity.CliPassword };
                    SqlParameter p_id = new SqlParameter() { ParameterName = "idClient", Value = id };

                    command.Parameters.Add(p_nom);
                    command.Parameters.Add(p_prenom);
                    command.Parameters.Add(p_CliMail);
                    command.Parameters.Add(p_CliCompany);
                    command.Parameters.Add(p_CliLogin);
                    command.Parameters.Add(p_CliPassword);
                    command.Parameters.Add(p_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
