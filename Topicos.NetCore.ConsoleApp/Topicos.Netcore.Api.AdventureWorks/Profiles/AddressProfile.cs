using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Topicos.Netcore.NorthWnd.Model.MyModels.Address, Api.AdventureWorks.MyDtoModels.Address>();
        }
    }
}
