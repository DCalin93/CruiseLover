using CruiseLover.DB.Entities;
using System.Collections.Generic;

namespace CruiseLover.Core.Interfaces
{
    public interface IShipService
    {
        IEnumerable<Ship> GetShips();
    }
}
