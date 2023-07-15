using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Domain.Response;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain.Interfaces;

public interface IProductDomain
{
    public ProductResponse GetById(int id);
    public Product Create(ProductRequest productRequest);
}