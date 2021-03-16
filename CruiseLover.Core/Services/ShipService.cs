using CruiseLover.Core.Interfaces;
using CruiseLover.DB;
using CruiseLover.DB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CruiseLover.Core.Services
{
    public class ShipService : IShipService
    {
        private CLDbContext _context;

        public ShipService(CLDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ship> GetShips()
        {
            return _context.Ships.ToList();
        }
    }
}
