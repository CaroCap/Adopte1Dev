
using System;

namespace Adopte1Dev.DAL.Entities
{
    public class Developer
    {
        public int idDev { get; set; }
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        public DateTime DevBirthDate { get; set; }
        public string? DevPicture { get; set; }
        public double DevHourCost { get; set; }
        public double DevDayCost { get; set; }
        public double DevMonthCost { get; set; }
        public string DevMail { get; set; }
        public string? DevCategPrincipal { get; set; }

        //public string? DevLogin { get; set; }
        //public string? DevPassword { get; set; }
    }
}
