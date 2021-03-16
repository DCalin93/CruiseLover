using CruiseLover.DB.Entities;
using System.Collections.Generic;

namespace CruiseLover.Core.Interfaces
{
    public interface ICruiseDetailService
    {
        IEnumerable<CruiseDetail> GetCruiseDetails();
        IEnumerable<CruiseDetail> GetFilteredData(int numberOfNights, string destinationList, string month, string year);
        IEnumerable<CruiseDetail> GetBestDeals();
    }
}
