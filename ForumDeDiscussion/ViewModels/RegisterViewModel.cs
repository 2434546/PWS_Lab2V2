﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ForumDeDiscussion.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Firstname")]
        public string Firstname { get; set; }

        [Required]
        [DisplayName("Nom d'utilisateur")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }
    }
}
