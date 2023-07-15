using AutoMapper;
using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain.Mapper;

public class RequestToModel: Profile
{
    public RequestToModel()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<MaintenanceActivityRequest, MaintenanceActivity>();
    }
}