using Adopte1Dev.BLL.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adpote1Dev.Models
{
    public class DeveloperDetails
    {
        [ScaffoldColumn(false)] // Pour que ça ne soit pas générer automatiquement dans ma vue
        [Key] // Pour préciser que c'est ma clef primaire
        public int idDev { get; set; }

        [DisplayName("Nom")]
        public string DevName { get; set; }

        [DisplayName("Prénom")]
        public string DevFirstName { get; set; }

        [DataType("datetime-local")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Date de Naissance")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Photo")]
        public string? DevPicture { get; set; }

        [DisplayName("Tarif horaire")]
        public double DevHourCost { get; set; }

        [DisplayName("Tarif journalier")]
        public double DevDayCost { get; set; }

        [DisplayName("Tarif mensuel")]
        public double DevMonthCost { get; set; }

        [EmailAddress]
        [DisplayName("Email")]
        public string DevMail { get; set; }

        [ScaffoldColumn(false)]
        public int? DevCategPrincipal { get; set; }

        [DisplayName("Langage principal")]
        public string CategName { get { return this.CategPrincipale?.CategLabel; } }
        public Categories CategPrincipale { get; set; }

    }
}
