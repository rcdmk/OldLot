using AutoMapper;
using OldLot.Dominio.Entidades;
using OldLot.Web.ViewModels;
using System.Linq;

namespace OldLot.Web.AutoMapper
{
    public class DominioParaViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DominioParaViewModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<Veiculo, VeiculoViewModel>()
                .ForMember(v => v.IdFabricante, m => m.MapFrom(d => d.Fabricante.Id))
                .ForMember(v => v.Fabricante, m => m.MapFrom(d => d.Fabricante.Nome))
                .ForMember(v => v.IdTipoDeVeiculo, m => m.MapFrom(d => d.Tipo.Id))
                .ForMember(v => v.Tipo, m => m.MapFrom(d => d.Tipo.Nome));

            CreateMap<Fabricante, FabricanteViewModel>()
                .ForMember(v => v.NumeroVeiculos, m => m.MapFrom(d => d.Veiculos.Count()));

            CreateMap<TipoDeVeiculo, TipoDeVeiculoViewModel>()
                .ForMember(v => v.NumeroVeiculos, m => m.MapFrom(d => d.Veiculos.Count()));
        }
    }
}