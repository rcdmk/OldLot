using AutoMapper;
using OldLot.Dominio.Entidades;
using OldLot.Web.ViewModels;

namespace OldLot.Web.AutoMapper
{
    public class ViewModelParaDominioMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelParaDominioMappingProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<VeiculoViewModel, Veiculo>()
                .ForMember(m => m.Fabricante, v => v.Ignore())
                .ForMember(m => m.Tipo, v => v.Ignore());

            CreateMap<FabricanteViewModel, Fabricante>()
                .ForMember(m => m.Veiculos, v => v.Ignore());

            CreateMap<TipoDeVeiculoViewModel, TipoDeVeiculo>()
                .ForMember(m => m.Veiculos, v => v.Ignore());
        }
    }
}