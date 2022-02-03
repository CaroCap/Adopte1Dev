using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adpote1Dev.Models
{
    public class LoginCreate
    {
        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        public string CliName { get; set; }
        
        [Required]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)] 
        public string CliFirstName { get; set; }

        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse n'est au bon format.")]
        [DisplayName("Email")] 
        public string CliMail { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Entreprise")] 
        public string CliCompany { get; set; }

        [Required(ErrorMessage = "Le login est obligatoire.")]
        [DataType(DataType.Text)]
        [DisplayName("Login : ")]
        public string CliLogin { get; set; }


        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe : ")]
        public string CliPassword { get; set; }
    }
}
