using AutoMapper;
using Portal.Noticias.Aplicacao.Models;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Aplicacao.Mappers
{
    public class NoticiaMapper : Profile
    {
        public NoticiaMapper()
        {
            CreateMap<Noticia, NoticiaModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(nt => nt.Tag)));

            CreateMap<NoticiaModel, Noticia>();
        }
    }
}
