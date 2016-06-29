using AutoMapper;
using OldLot.API.Models;
using OldLot.Dominio.Entidades;

namespace OldLot.API.AutoMapper
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
            CreateMap<Veiculo, VeiculoModel>();
            CreateMap<Fabricante, FabricanteModel>();
            CreateMap<TipoDeVeiculo, TipoDeVeiculoModel>();
        }
    }
}