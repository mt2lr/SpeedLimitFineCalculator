using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service;

public interface IVehicleLimitCalculator
{
    int GetVehicleLimitByRoadType(VehicleType vehicleType, RoadType roadType);
}