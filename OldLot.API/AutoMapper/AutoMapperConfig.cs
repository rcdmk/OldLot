using AutoMapper;

namespace OldLot.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DominioParaViewModelMappingProfile>();
                m.AddProfile<ViewModelParaDominioMappingProfile>();
            });
        }
    }
}