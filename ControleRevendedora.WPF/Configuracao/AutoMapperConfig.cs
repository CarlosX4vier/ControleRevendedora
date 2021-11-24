using AutoMapper;

namespace ControleRevendedora.Configuracao
{
    public class AutoMapperConfig
    {
        public static IMapper AutoMapper;
        public AutoMapperConfig()
        {
            var autoMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoVO, Modelos.Produto>()
                .ForMember(vo => vo.Nome, e => e.MapFrom(i => i.description))
                .ForMember(vo => vo.CodigoBarras, e => e.MapFrom(i => i.gtin))
                .ForMember(vo => vo.Imagem, e => e.MapFrom(i => i.thumbnail))
                .ForPath(vo => vo.Marca.Nome, e => e.MapFrom(i => i.brand.name));

            });


            AutoMapper = autoMapperConfiguration.CreateMapper();
        }
    }
}
