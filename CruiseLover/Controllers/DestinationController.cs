using CruiseLover.Core.Interfaces;
using CruiseLover.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CruiseLover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly ILogger<DestinationController> _logger;
        private IDestinationService _destinationService;

        public DestinationController(ILogger<DestinationController> logger, IDestinationService destinationService)
        {
            _logger = logger;
            _destinationService = destinationService;
        }

        [HttpGet]
        public IEnumerable<string> GetDestinationNames()
        {
            return _destinationService.GetDestinationNames();
        }

        [Route("[controller]/allDestinations")]
        [HttpGet("allDestinations")]
        public IEnumerable<Destination> GetDestinations()
        {
            return _destinationService.GetDestinations();
        }
    }
}
