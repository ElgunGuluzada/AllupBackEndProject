﻿using AllupBackEndProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllupBackEndProject.ViewModels
{
    public class RegisterVM
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        public string Fullname { get; set; }
        [Required, StringLength(100)]
        public string Username { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
