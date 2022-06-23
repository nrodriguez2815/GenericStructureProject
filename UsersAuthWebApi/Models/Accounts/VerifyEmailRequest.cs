﻿using System.ComponentModel.DataAnnotations;

namespace UsersAuthWebApi.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
