using AutoMapper;
using si730ebu20201b051.Domain.Interfaces;
using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Infraestructure.Interfaces;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain.Response;

public class MaintenanceActivityDomain: IMaintenanceActivityDomain
{
    private IMaintenanceActivityInfraestructure _maintenanceActivityInfraestructure;
    private IProductInfrastructure _productInfrastructure;
    private IMapper _mapper;

    public MaintenanceActivityDomain(IMaintenanceActivityInfraestructure maintenanceActivityInfraestructure,
        IProductInfrastructure productInfrastructure, IMapper mapper)
    {
        _maintenanceActivityInfraestructure = maintenanceActivityInfraestructure;
        _productInfrastructure = productInfrastructure;
        _mapper = mapper;
    }

    public MaintenanceActivity Create(MaintenanceActivityRequest maintenanceActivityRequest)
    {
        Product product = _productInfrastructure.GetBySerialNumber(maintenanceActivityRequest.productSerialNumber);
        if (product == null)
        {
            throw new Exception("El número de serie no pertenece a ningun producto.");
        }
        
        MaintenanceActivity maintenanceActivity =
            _mapper.Map<MaintenanceActivityRequest, MaintenanceActivity>(maintenanceActivityRequest);

        if (product.status != 1 && maintenanceActivity.activityResult == 1)
        {
            _productInfrastructure.UpdateStatus(product.id, 1);
        }
        if (product.status != 2 && maintenanceActivity.activityResult == 0)
        {
            _productInfrastructure.UpdateStatus(product.id, 2);
        }

        return _maintenanceActivityInfraestructure.Create(maintenanceActivity);
    }
}