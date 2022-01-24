using System;
using System.Collections.Generic;
using System.Text;

namespace Adopte1Dev.BLL.Entities
{
    public class DeveloperBLL
    {
        // Les mêmes propriétés que celles du DAL
        public int idDev { get; set; }
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        public DateTime DevBirthDate { get; set; }
        public string? DevPicture { get; set; }
        public double DevHourCost { get; set; }
        public double DevDayCost { get; set; }
        public double DevMonthCost { get; set; }
        public string DevMail { get; set; }
        public int? DevCategPrincipal { get; set; }

        // Constructeur 
        public DeveloperBLL(int IdDev, string devName, string devFirstName, DateTime devBirthDate, string? devPicture, double devHourCost, double devDayCost, double devMonthCost, string devMail, string? devCategPrincipal)
        {
            idDev = IdDev;
            DevName = devName;
            DevFirstName = devFirstName;
            DevBirthDate = devBirthDate;
            DevPicture = devPicture;
            DevHourCost = devHourCost;
            DevDayCost = devDayCost;
            DevMonthCost = devMonthCost;
            DevMail = devMail;
            DevCategPrincipal = (devCategPrincipal is null)? null : (int?)int.Parse(devCategPrincipal);
        }
    }
}
