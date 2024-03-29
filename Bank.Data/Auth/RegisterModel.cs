﻿using Bank.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Auth
{
    public class RegisterModel : CustomerDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
