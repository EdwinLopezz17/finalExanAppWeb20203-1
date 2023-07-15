using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Infraestructure.Interfaces;

public interface IProductInfrastructure
{
    public Product GetById(int id);
    public Product GetBySerialNumber(string serialNumber);
    public Product Create(Product product);
    public Product UpdateStatus(int id, int status);

}