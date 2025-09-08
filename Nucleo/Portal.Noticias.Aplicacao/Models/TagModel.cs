using System.ComponentModel.DataAnnotations;

namespace Portal.Noticias.Aplicacao.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da Tag é obrigatório")]
        [StringLength(100, ErrorMessage = "O máximo de caracteres permitido é 100")]
        public string? Descricao { get; set; }
    }
}
