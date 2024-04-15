using Codecool.SpeedLimitFineCalculator.Model;

namespace Codecool.SpeedLimitFineCalculator.Service;

public interface ISpeedLimitFineCalculator
{
    double CalculateSpeedLimitFine(VehicleType vehicleType, RoadType roadType, double actualSpeed);
}