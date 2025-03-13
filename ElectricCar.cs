using System; 

namespace CarApp.Models;

public class ElectricCar : Car 
{ 
    // Additional property for battery level 
    public double BatteryLevel { get; set; } 
 
    // Constructor to initialize the ElectricCar with default battery level 
    public ElectricCar() : base()
    { 
        BatteryLevel = 100; // Default battery level 
    } 
    public ElectricCar(string color, string model) : base(color, model)
    {
        BatteryLevel = 100;
    }
 
    // Override the Drive method to use battery instead of fuel 
    public override void Drive(int distance) 
    { 
        if (BatteryLevel >= distance * 2) // Check if the battery is sufficient 
        { 
            BatteryLevel -= distance * 2; // Assume 2% battery consumption per km 
            Console.WriteLine($"{Color} {Model} (Electric) drove {distance} km. Remaining battery: {BatteryLevel:F1}%"); 
        } 
        else 
        { 
            base.Drive(distance); // Use the base class's fuel-based driving logic 
        } 
    } 
}
