

using System.ComponentModel.DataAnnotations;

namespace Adpote1Dev.Models
{
    public class DeveloperListItem
    {
        [ScaffoldColumn(false)] // Pour que ça ne soit pas générer automatiquement dans ma vue
        [Key] // Pour préciser que c'est ma clef primaire
        public int idDev { get; set; }
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        public string? DevPicture { get; set; }
        public string? DevCategPrincipal { get; set; }

    }
}
