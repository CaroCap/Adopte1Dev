using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adpote1Dev.Models
{
    public class Categories
    {
        [ScaffoldColumn(false)]
        [Key]
        public int idCategory { get; set; }
        [DisplayName("Langage de Programmation")]
        public string CategLabel { get; set; }
    }
}
