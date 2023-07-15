using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using si730ebu20201b051.Domain.Interfaces;
using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.API.Controllers
{
    [Route("api/v1/maintenance-activities")]
    [ApiController]
    public class MaintenanceActivityController : ControllerBase
    {

        private IMaintenanceActivityDomain _maintenanceActivityDomain;
        
        
        public MaintenanceActivityController(IMaintenanceActivityDomain maintenanceActivityDomain)
        {
            _maintenanceActivityDomain = maintenanceActivityDomain;
        }

        // POST: api/v1/products/{productId}/maintenance-activities
        [HttpPost]
        public MaintenanceActivity Post([FromBody] MaintenanceActivityRequest maintenanceActivityRequest)
        {
            return _maintenanceActivityDomain.Create(maintenanceActivityRequest);
        }

    }
}
