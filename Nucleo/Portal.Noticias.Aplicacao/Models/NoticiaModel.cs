using Portal.Noticias.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Portal.Noticias.Aplicacao.Models
{
    public class NoticiaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [Display(Name = "Título")]
        [StringLength(200, ErrorMessage = "O máximo de caracteres permitido é 200")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        public string Texto { get; set; } = string.Empty;
        public int UsuarioId { get; set; }

        public ICollection<Tag> Tags { get; set; } = [];
        public string TagsFormatado => string.Join(", ", Tags.Select(t => t.Descricao));
        public List<int> TagsIds { get; set; } = [];
    }
}
