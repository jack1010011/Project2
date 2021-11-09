using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.Profiles
{
    public class DtoAddressProfile : Profile
    {
        public DtoAddressProfile()
        {
            CreateMap<Topicos.Netcore.NorthWnd.Model.MyModels.Address, Topicos.Netcore.Api.AdventureWorks.MyDtoModels.DtoAddress>();
        }
    }
}
