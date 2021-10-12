using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdopteDevWebApp.Models.User
{
    public class AddUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Un nom est obligatoire.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Une addresse email est obligatoire.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Un mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Un numéro de téléphone est obligatoire.")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "True: pour Client / False: pour Développeur")]
        public bool IsClient { get; set; }
    }
}
