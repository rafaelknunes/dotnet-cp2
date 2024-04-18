﻿using System.ComponentModel.DataAnnotations;

namespace FIAP_MVC.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do Email está incorreto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
