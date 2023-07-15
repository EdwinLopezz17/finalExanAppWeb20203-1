using AutoMapper;
using si730ebu20201b051.Domain.Interfaces;
using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Domain.Response;
using si730ebu20201b051.Infraestructure.Interfaces;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain;

public class ProductDomain : IProductDomain
{
    private IProductInfrastructure _productInfrastructure;
    private IMapper _mapper;
    
    public ProductDomain(IProductInfrastructure productInfrastructure, IMapper mapper)
    {
        _productInfrastructure = productInfrastructure;
        _mapper = mapper;
    }

    public ProductResponse GetById(int id)
    {
        Product product = _productInfrastructure.GetById(id);
        ProductResponse productResponse = _mapper.Map<Product, ProductResponse>(product);
        if (product.status == 1)
        {
            productResponse.statusDescription = "OPERATIONAL";
        }
        else
        {
            productResponse.statusDescription = "UNOPERATIONAL";
        }

        return productResponse;
    }

    public Product Create(ProductRequest productRequest)
    {
        Product existProduct = _productInfrastructure.GetBySerialNumber(productRequest.serialNumber);
        if (existProduct != null)
        {
            throw new Exception("El número de serie ya está en uso.");
        }
        
        Product product = _mapper.Map<ProductRequest, Product>(productRequest);
        if (productRequest.statusDescription == "OPERATIONAL")
        {
            product.status = 1;
        }
        else
        {
            product.status = 2;
        }

        return _productInfrastructure.Create(product);
    }
}