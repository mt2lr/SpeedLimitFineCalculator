using Codecool.SpeedLimitFineCalculator.Model;
using Codecool.SpeedLimitFineCalculator.Service.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.SpeedLimitFineCalculator.Service
{
    internal class SpeedLimitFineCalculator : ISpeedLimitFineCalculator
    {
        private readonly IVehicleLimitCalculator _vehicleLimitCalculator;
        private readonly ILogger _logger;
        public SpeedLimitFineCalculator(IVehicleLimitCalculator vehicleLimitCalculator, ILogger logger)
        {
            _vehicleLimitCalculator = vehicleLimitCalculator;
            _logger = logger;
        }

        public double CalculateSpeedLimitFine(VehicleType vehicleType, RoadType roadType, double actualSpeed)
        {
            double speedLimit = Convert.ToDouble(_vehicleLimitCalculator.GetVehicleLimitByRoadType(vehicleType, roadType));

            _logger.LogInfo($"Checking vehicle '{vehicleType}' on road '{roadType}' with '{actualSpeed}' speed. Speedlimit is '{speedLimit}'.");

            

            if (speedLimit < actualSpeed)
            {            
                return (actualSpeed + 100 )/ speedLimit * 15;
            }
            else
            {
                return 0;
            }
            
        }

    }
}
