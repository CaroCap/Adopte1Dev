using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adpote1Dev.Models
{
    public class DeveloperCreateForm
    {
        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string DevName { get; set; }

        [Required]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        public string DevFirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[DataType("datetime-local")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Date de Naissance")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Photo")]
        [DataType(DataType.Text)]
        public string? DevPicture { get; set; }

        [Required]
        [DisplayName("Tarif horaire")]
        [DataType(DataType.Currency)]
        public double DevHourCost { get; set; }

        [Required]
        [DisplayName("Tarif journalier")]
        [DataType(DataType.Currency)]
        public double DevDayCost { get; set; }

        [Required]
        [DisplayName("Tarif mensuel")]
        [DataType(DataType.Currency)]
        public double DevMonthCost { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string DevMail { get; set; }


        //[ScaffoldColumn(false)]
        //public int? DevCategPrincipal { get; set; }

        //[DisplayName("Langage principal")]
        //public string CategName { get { return this.CategPrincipale?.CategLabel; } }
        //public Categories CategPrincipale { get; set; }
        

        [DisplayName("Langage principal")]
        //IEnumerable sert pour l'affichage des options du Select dans la view
        public IEnumerable<Categories> CategoriesList { get; set; }
        
        [ScaffoldColumn(false)]
        public int? DevCategPrincipal { get; set; }

        //public string CategName { get; set; }
        //public Categories CategPrincipale { get; set; }
    }
}
