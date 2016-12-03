using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Harjoitustyo___Ruokapaivakirja.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Nimi on pakollinen.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sähköposti on pakollinen.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Sähköposti on viallinen.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Käyttäjätunnus on pakollinen.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Salasana on pakollinen.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Salasanan vahvistus on pakollinen.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}