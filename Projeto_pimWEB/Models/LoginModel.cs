using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Projeto_pimWEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? password { get; set; }

    }
}
