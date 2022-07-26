﻿using System.ComponentModel.DataAnnotations;

namespace AllupBackEndProject.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
