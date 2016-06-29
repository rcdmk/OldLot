using AutoMapper;
using OldLot.API.Models;
using OldLot.Dominio.Entidades;

namespace OldLot.API.AutoMapper
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
            CreateMap<VeiculoModel, Veiculo>()
                .ForMember(p => p.Id, m => m.Ignore());

            CreateMap<FabricanteModel, Fabricante>();
            CreateMap<TipoDeVeiculoModel, TipoDeVeiculo>();
        }
    }
}