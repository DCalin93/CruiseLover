using CruiseLover.Core.Interfaces;
using CruiseLover.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CruiseLover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CruiseDetailController : ControllerBase
    {
        private readonly ILogger<CruiseDetailController> _logger;
        private ICruiseDetailService _cruiseDetailService;

        public CruiseDetailController(ILogger<CruiseDetailController> logger, ICruiseDetailService cruiseDetailService)
        {
            _logger = logger;
            _cruiseDetailService = cruiseDetailService;
        }

        [HttpGet]
        public IEnumerable<CruiseDetail> Get()
        {
            return _cruiseDetailService.GetCruiseDetails();
        }

        [Route("[controller]/{numberOfNights}&{destinations}&{month}&{year}")]
        [HttpGet("{numberOfNights}&{destinations}&{month}&{year}")]
        public IEnumerable<CruiseDetail> GetFilteredData(int numberOfNights, string destinations, string month, string year)
        {
            var x = _cruiseDetailService.GetFilteredData(numberOfNights, destinations, month, year);
            return _cruiseDetailService.GetFilteredData(numberOfNights, destinations, month, year);
        }

        [Route("[controller]/bestDeals")]
        [HttpGet("bestDeals")]
        public IEnumerable<CruiseDetail> GetBestDeals()
        {
            return _cruiseDetailService.GetBestDeals();
        }
    }
}
