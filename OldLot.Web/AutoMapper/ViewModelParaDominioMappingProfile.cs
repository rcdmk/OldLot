using AutoMapper;
using OldLot.Dominio.Entidades;
using OldLot.Web.ViewModels;
using System.Linq;

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
            CreateMap<VeiculoViewModel, Veiculo>();
            CreateMap<FabricanteViewModel, Fabricante>();
        }
    }
}