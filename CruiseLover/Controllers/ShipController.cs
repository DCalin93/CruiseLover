using CruiseLover.Core.Interfaces;
using CruiseLover.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CruiseLover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private IShipService _shipService;

        public ShipController(ILogger<ShipController> logger, IShipService shipService)
        {
            _logger = logger;
            _shipService = shipService;
        }

        [HttpGet]
        public IEnumerable<Ship> Get()
        {
            return _shipService.GetShips();
        }
    }
}
