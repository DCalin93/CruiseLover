using CruiseLover.Core.Interfaces;
using CruiseLover.DB;
using CruiseLover.DB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CruiseLover.Core.Services
{
    public class DestinationService : IDestinationService
    {
        private CLDbContext _context;

        public DestinationService(CLDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetDestinationNames()
        {
            return _context.Destinations.Select(d => d.Name).ToList();
        }

        public IEnumerable<Destination> GetDestinations()
        {
            return _context.Destinations.ToList();
        }
    }
}
