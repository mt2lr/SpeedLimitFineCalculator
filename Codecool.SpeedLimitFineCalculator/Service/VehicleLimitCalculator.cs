using Codecool.SpeedLimitFineCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.SpeedLimitFineCalculator.Service
{
    internal class VehicleLimitCalculator : IVehicleLimitCalculator
    {

        public int GetVehicleLimitByRoadType(VehicleType vehicleType, RoadType roadType)
        {
            Dictionary<string, Dictionary<string, int>> speedLimitTable = new Dictionary<string, Dictionary<string, int>>
                {
                    { "Urban", new Dictionary<string, int> { { "Car", 50 }, { "Bus", 50 }, { "Truck", 50 } } },
                    { "MainRoad", new Dictionary<string, int> { { "Car", 90 }, { "Bus", 70 }, { "Truck", 70 } } },
                    { "Highway", new Dictionary<string, int> { { "Car", 130 }, { "Bus", 100 }, { "Truck", 80 } } }
                };
            return speedLimitTable[roadType.ToString()][vehicleType.ToString()];

        }
    }
}
