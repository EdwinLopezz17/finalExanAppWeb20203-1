using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Domain.Interfaces;

public interface IMaintenanceActivityDomain
{
    public MaintenanceActivity Create(MaintenanceActivityRequest maintenanceActivityRequest);
}