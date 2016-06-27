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
            CreateMap<Veiculo, VeiculoViewModel>();
            CreateMap<Fabricante, FabricanteViewModel>().ForMember(v => v.NumeroVeiculos, m => m.MapFrom(d => d.Veiculos.Count()));
            CreateMap<TipoDeVeiculo, TipoDeVeiculoViewModel>().ForMember(v => v.NumeroVeiculos, m => m.MapFrom(d => d.Veiculos.Count()));
        }
    }
}