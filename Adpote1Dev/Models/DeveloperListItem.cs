

using Adopte1Dev.BLL.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adpote1Dev.Models
{
    public class DeveloperListItem
    {
        [ScaffoldColumn(false)] // Pour que ça ne soit pas générer automatiquement dans ma vue
        [Key] // Pour préciser que c'est ma clef primaire
        public int idDev { get; set; }

        [DisplayName("Nom")]
        public string DevName { get; set; }

        [DisplayName("Prénom")]
        public string DevFirstName { get; set; }

        [DisplayName("Photo")]
        public string? DevPicture { get; set; }

        [ScaffoldColumn(false)]
        public int? DevCategPrincipal { get; set; }

        [DisplayName("Langage principal")]
        public string CategName { get { return this.CategPrincipale?.CategLabel; } }
        public Categories CategPrincipale {get; set;}

    }
}
