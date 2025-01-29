using AutoMapper;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.Entities;

namespace Logistics.Management.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Order, RequestOrderResponse>();
    }
}