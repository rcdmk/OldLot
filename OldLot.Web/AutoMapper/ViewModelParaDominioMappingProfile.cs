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
                .ForMember(m => m.Fabricante, v => v.MapFrom(m => new Fabricante() { Id = m.IdFabricante, Nome = m.Fabricante }))
                .ForMember(m => m.Tipo, v => v.MapFrom(m => new TipoDeVeiculo() { Id = m.IdTipoDeVeiculo, Nome = m.Tipo }));

            CreateMap<FabricanteViewModel, Fabricante>();
            CreateMap<TipoDeVeiculoViewModel, TipoDeVeiculo>();
        }
    }
}