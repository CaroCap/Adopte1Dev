using Adopte1Dev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Adopte1Dev.DAL.Handlers
{
    public static class Mapper
    {
        public static Client ToClient(IDataRecord record)
        {
            if (record is null) return null;
            return new Client
            {
                idClient = (int)record[nameof(Client.idClient)],
                CliName = (string)record[nameof(Client.CliName)],
                CliFirstName = (string)record[nameof(Client.CliFirstName)],
                CliMail = (string)record[nameof(Client.CliMail)],
                CliCompany = (string)record[nameof(Client.CliCompany)],
                CliLogin = (string)record[nameof(Client.CliLogin)],
                CliPassword = (string)record[nameof(Client.CliPassword)]
                /// Si une colone est nullable, il faut faire un test de sa nullité avant de l'envoyer dans le DTO
                //CliLogin = (record[nameof(Client.CliLogin)] is DBNull) ? null : (string?)record[nameof(Client.CliLogin)],
                //CliPassword = (record[nameof(Client.CliPassword)] is DBNull) ? null : (string)record[nameof(Client.CliPassword)]
            };
        }
        public static Developer ToDeveloper(IDataRecord record)
        {
            if (record is null) return null;
            return new Developer
            {
                idDev = (int)record[nameof(Developer.idDev)],
                DevName = (string)record[nameof(Developer.DevName)],
                DevFirstName = (string)record[nameof(Developer.DevFirstName)],
                DevBirthDate = (DateTime)record[nameof(Developer.DevBirthDate)],
                DevPicture = (string)record[nameof(Developer.DevPicture)],
                //DevPicture = (record[nameof(Developer.DevPicture)] is DBNull) ? null : (string?)record[nameof(Developer.DevPicture)],
                DevHourCost = (float)record[nameof(Developer.DevHourCost)],
                DevDayCost = (float)record[nameof(Developer.DevDayCost)],
                DevMonthCost = (float)record[nameof(Developer.DevMonthCost)],
                DevMail = (string)record[nameof(Developer.DevDayCost)],
                DevCategPrincipal = (string)record[nameof(Developer.DevCategPrincipal)]
                /// Si une colone est nullable, il faut faire un test de sa nullité avant de l'envoyer dans le DTO
                //DevCategPrincipal = (record[nameof(Developer.DevCategPrincipal)] is DBNull) ? null : (string?)record[nameof(Developer.DevCategPrincipal)],
            };
        }
    }
}
