using System.ComponentModel.DataAnnotations;

namespace FIAP_MVC.DTOs
{
    public class RegisterDTO
    {
        // Required indica que o atributo é obrigatório
        [Required]
        public string UserName { get; set; } 

        [Required]
        [EmailAddress] // Valida o Email
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } 

        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Senhas devem ser iguais")]
        public string ComparePassword { get; set; } 

        public string UserPhone { get; set; } 

    }
}