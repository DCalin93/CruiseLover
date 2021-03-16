using CruiseLover.Core.Interfaces;
using CruiseLover.DB;
using CruiseLover.DB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseLover.Core
{
    public class CruiseDetailService : ICruiseDetailService
    {
        private CLDbContext _context;

        public CruiseDetailService(CLDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CruiseDetail> GetCruiseDetails()
        {
            var cruiseDetails = _context.CruiseDetails.ToList();
            var ships = _context.Ships.ToList();

            for (var i = 0; i < cruiseDetails.Count; i++)
            {
                cruiseDetails[i].Ship = ships.FirstOrDefault(s => s.Id == cruiseDetails[i].ShipId);
            }

            return cruiseDetails;
        }

        public IEnumerable<CruiseDetail> GetFilteredData(int numberOfNights, string destinations, string month, string year)
        {
            var monthValue = Int32.Parse(month);
            var yearValue = Int32.Parse("20" + year);
            var ships = _context.Ships.ToList();
            List<CruiseDetail> result = new List<CruiseDetail>();
            List<string> destinationList = JsonConvert.DeserializeObject<List<string>>(destinations);

            switch (numberOfNights)
            {
                case 24:
                    result = _context.CruiseDetails.Where(c => c.Nights >= 2 && c.Nights <= 4 &&
                        (c.DepartureDate.Month >= monthValue && c.DepartureDate.Year >= yearValue) &&
                        (destinationList.Count != 0 ? destinationList.Contains(c.Destination.Name) : true)).ToList();
                    break;
                case 57:
                    result = _context.CruiseDetails.Where(c => c.Nights >= 5 && c.Nights <= 7 &&
                        (c.DepartureDate.Month >= monthValue && c.DepartureDate.Year >= yearValue) &&
                        (destinationList.Count != 0 ? destinationList.Contains(c.Destination.Name) : true)).ToList();
                    break;
                case 810:
                    result = _context.CruiseDetails.Where(c => c.Nights >= 8 && c.Nights <= 10 &&
                        (c.DepartureDate.Month >= monthValue && c.DepartureDate.Year >= yearValue) &&
                        (destinationList.Count != 0 ? destinationList.Contains(c.Destination.Name) : true)).ToList();
                    break;
                case 11:
                    result = _context.CruiseDetails.Where(c => c.Nights >= 11 &&
                        (c.DepartureDate.Month >= monthValue && c.DepartureDate.Year >= yearValue) &&
                        (destinationList.Count != 0 ? destinationList.Contains(c.Destination.Name) : true)).ToList();
                    break;
                default:
                    result = _context.CruiseDetails.Where(c => c.DepartureDate.Month >= monthValue && c.DepartureDate.Year >= yearValue &&
                        (destinationList.Count == 0 || destinationList.Contains(c.Destination.Name))).ToList();
                    break;
            }

            for (var i = 0; i < result.Count; i++)
            {
                result[i].Ship = ships.FirstOrDefault(s => s.Id == result[i].ShipId);
            }

            return result;
        }

        public IEnumerable<CruiseDetail> GetBestDeals()
        {
            var cruiseDetails = _context.CruiseDetails.Where(c => c.HasDiscount).ToList();
            var ships = _context.Ships.ToList();

            for (var i = 0; i < cruiseDetails.Count; i++)
            {
                cruiseDetails[i].Ship = ships.FirstOrDefault(s => s.Id == cruiseDetails[i].ShipId);
                cruiseDetails[i].Price = Math.Floor((double)(cruiseDetails[i].Price - (cruiseDetails[i].Price * cruiseDetails[i].Discount)));
            }

            return cruiseDetails;
        }
    }
}
