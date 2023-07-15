using AutoMapper;
using si730ebu20201b051.Domain.Response;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain.Mapper;

public class ModelToResponse: Profile
{
    public ModelToResponse()
    {
        CreateMap<Product, ProductResponse>();
    }
}