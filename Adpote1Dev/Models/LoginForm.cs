using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adpote1Dev.Models
{
    public class LoginForm
    {
        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse n'est au bon format.")]
        [DisplayName("Adresse électronique : ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$", ErrorMessage = "Le mot de passe doit au minimum un nombre, une minuscule, une majuscule, un caractère parmis '@#$%^&-+=()', aucun espace blanc, compris entre 8 et 20 caractères.")]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe : ")]
        public string Passwd { get; set; }

    }
}
