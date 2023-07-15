using si730ebu20201b051.Infraestructure.Context;
using si730ebu20201b051.Infraestructure.Interfaces;

namespace si730ebu20201b051.Infraestructure.Models;

public class MaintenanceActivityInfraestructure: IMaintenanceActivityInfraestructure
{
    private U20201b051DBContext _u20201B051DbContext;
    
    public MaintenanceActivityInfraestructure(U20201b051DBContext context)
    {
        _u20201B051DbContext = context;
    }


    public MaintenanceActivity Create(MaintenanceActivity maintenanceActivity)
    {
        _u20201B051DbContext.Add(maintenanceActivity);
        _u20201B051DbContext.SaveChanges();
        return maintenanceActivity;
    }
}