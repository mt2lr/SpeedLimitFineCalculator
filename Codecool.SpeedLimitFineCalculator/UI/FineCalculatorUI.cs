
using Codecool.SpeedLimitFineCalculator.Model;
using Codecool.SpeedLimitFineCalculator.Service;
using Codecool.SpeedLimitFineCalculator.Service.Logger;
using System.Diagnostics.Metrics;

namespace Codecool.SpeedLimitFineCalculator.UI;

public class FineCalculatorUi
{
    private readonly ISpeedLimitFineCalculator _speedLimitFineCalculator;

    public FineCalculatorUi(ISpeedLimitFineCalculator speedLimitFineCalculator)
    {
        _speedLimitFineCalculator = speedLimitFineCalculator;
    }

    public void Run()
    {
        GreetUser();

        var vehicleTypeEnum = SelectVehicleType();
        var roadTypeEnum = SelectRoadType();
        var speed = GetSpeed();

        VehicleLimitCalculator vehicleLimitCalculator = new VehicleLimitCalculator();
        double fine = _speedLimitFineCalculator.CalculateSpeedLimitFine(vehicleTypeEnum, roadTypeEnum, speed);

        if (fine == 0)
        {
            Console.WriteLine("You are within speed limits! No fine applies.");
        }
        else
        {
            Console.WriteLine($"Your fine is {fine} CodeCoins :(");
        }

        Console.ReadKey();
    }

    private static VehicleType SelectVehicleType()
    {
        int input;
        VehicleType[] allVehicleTypes = (VehicleType[])Enum.GetValues(typeof(VehicleType));
        string output = "Enter the vehicletype ";
        for (int i = 0; i < allVehicleTypes.Length; i++)
        {
            output += $"{allVehicleTypes[i]}({i}), ";
        }
        output = output.Substring(0, output.Length - 2);
        output += "!";

        do
        {
            Console.WriteLine(output);
        } while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > allVehicleTypes.Length-1);

        return allVehicleTypes[input];
    }
    
    private static RoadType SelectRoadType()
    {
        int input;
        RoadType[] allRoadTypes = (RoadType[])Enum.GetValues(typeof(RoadType));
        string output = "Enter the roadtype ";
        for (int i = 0; i < allRoadTypes.Length; i++)
        {
            output += $"{allRoadTypes[i]}({i}), ";
        }
        output = output.Substring(0, output.Length - 2);
        output += "!";

        do
        {
            Console.WriteLine(output);
        } while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > allRoadTypes.Length-1);

        return allRoadTypes[input];
    }

    private int GetSpeed()
    {
        int input;
        do
        {
            Console.WriteLine("Enter the speed (km/h)!");
        } while (!int.TryParse(Console.ReadLine(),out input) || input < 0);
        return input;
    }
    

    private static void GreetUser()
    {
        Console.WriteLine(
            "Hi! You were on the road again, but you were a bit too fast, weren't you? No worries, let's see how much it will cost you!");
    }
}
