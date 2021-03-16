using CruiseLover.DB.Entities;
using System.Collections.Generic;

namespace CruiseLover.Core.Interfaces
{
    public interface IDestinationService
    {
        IEnumerable<Destination> GetDestinations();
        IEnumerable<string> GetDestinationNames();
    }
}
