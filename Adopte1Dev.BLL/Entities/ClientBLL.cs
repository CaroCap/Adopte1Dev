using System;
using System.Collections.Generic;
using System.Text;

namespace Adopte1Dev.BLL.Entities
{
    public class ClientBLL
    {
        public ClientBLL(int idClient, string cliName, string cliFirstName, string cliMail, string cliCompany, string? cliLogin, string? cliPassword)
        {
            this.idClient = idClient;
            CliName = cliName;
            CliFirstName = cliFirstName;
            CliMail = cliMail;
            CliCompany = cliCompany;
            CliLogin = cliLogin;
            CliPassword = cliPassword;
        }

        // Les mêmes propriétés que celles du DAL
        public int idClient { get; set; }
        public string CliName { get; set; }
        public string CliFirstName { get; set; }
        public string CliMail { get; set; }
        public string CliCompany { get; set; }
        public string? CliLogin { get; set; }
        public string? CliPassword { get; set; }
    }
}
