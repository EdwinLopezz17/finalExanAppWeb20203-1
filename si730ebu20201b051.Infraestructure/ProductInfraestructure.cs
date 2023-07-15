using si730ebu20201b051.Infraestructure.Context;
using si730ebu20201b051.Infraestructure.Interfaces;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Infraestructure;

public class ProductInfraestructure: IProductInfrastructure
{
    private U20201b051DBContext _u20201B051DbContext;
    
    public ProductInfraestructure(U20201b051DBContext context)
    {
        _u20201B051DbContext = context;
    }

    public Product GetById(int id)
    {
        return _u20201B051DbContext.Products.Find(id);
    }

    public Product GetBySerialNumber(string serialNumber)
    {
        return _u20201B051DbContext.Products.FirstOrDefault(p => p.serialNumber == serialNumber);
    }

    public Product Create(Product product)
    {
        _u20201B051DbContext.Products.Add(product);
        _u20201B051DbContext.SaveChanges();
        return product;
    }

    public Product UpdateStatus(int id, int status)
    {
        Product product = _u20201B051DbContext.Products.Find(id);
        product.status = status;
        _u20201B051DbContext.Products.Update(product);
        _u20201B051DbContext.SaveChanges();
        return product;
    }

}