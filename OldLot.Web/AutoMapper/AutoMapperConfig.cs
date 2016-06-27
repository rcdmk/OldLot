using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OldLot.Web.AutoMapper
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