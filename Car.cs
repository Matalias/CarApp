using System; 

namespace CarApp.Models;
 
public class Car 
{ 
    // Public properties for color and model 
    public string Color { get; set; } = "Unknown"; // Elakkan null
    public string Model { get; set; } = "Unknown"; // Elakkan null

    // Protected property for fuel level (accessible within the class and derived classes) 
    protected double FuelLevel { get; set; } 
 
    // Default Constructor
    public Car() 
    { 
        FuelLevel = 100; // Default fuel level 
    } 
    public Car(string color, string model)
    {
        Color = color;
        Model = model;
        FuelLevel = 100;
    }

    // Virtual method to drive the car (can be overridden in derived classes) 
    public virtual void Drive(int distance) 
    { 
        if (CanDrive(distance)) // Check if the car can drive the given distance 
        { 
            FuelLevel -= distance * 0.5; // Assume 0.5 fuel units per km 
            Console.WriteLine($"{Color} {Model} drove {distance} km. Remaining fuel: {FuelLevel:F1}%"); 
        } 
        else 
        { 
            Console.WriteLine($"{Color} {Model} doesn't have enough fuel to drive {distance} km."); 
        } 
    } 
    public double DriveWithReturn(int distance)
    {
        Drive(distance);
        return FuelLevel;
    }

    // Protected method to check if the car can drive the given distance 
    protected bool CanDrive(int distance) 
    { 
        return FuelLevel >= distance * 0.5; 
    } 
} 
