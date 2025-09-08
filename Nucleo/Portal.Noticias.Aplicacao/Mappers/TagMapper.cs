using AutoMapper;
using Portal.Noticias.Aplicacao.Models;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Aplicacao.Mappers
{
    public class TagMapper : Profile
    {
        public TagMapper()
        {
            CreateMap<Tag, TagModel>().ReverseMap();
        }
    }
}
