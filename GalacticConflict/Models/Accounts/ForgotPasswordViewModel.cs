﻿using System.ComponentModel.DataAnnotations;

namespace InterGalacticConflict.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
