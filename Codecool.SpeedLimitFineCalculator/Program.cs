using Codecool.SpeedLimitFineCalculator.Service;
using Codecool.SpeedLimitFineCalculator.Service.Logger;
using Codecool.SpeedLimitFineCalculator.UI;

namespace Codecool.SpeedLimitFineCalculator;

internal static class Program
{
    public static void Main(string[] args)
    {
        ILogger fileLogger = new FileLogger("log.txt");
        IVehicleLimitCalculator vehicleLimitCalculator = new VehicleLimitCalculator();
        ISpeedLimitFineCalculator speedLimitFineCalculator = new Service.SpeedLimitFineCalculator(vehicleLimitCalculator, fileLogger);
        var fineCalculatorUi = new FineCalculatorUi(speedLimitFineCalculator);
        fineCalculatorUi.Run();
    }
}