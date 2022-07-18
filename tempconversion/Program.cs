using System;

namespace TempConversion;

class Program
{

    public static void Main()
    {
        Console.WriteLine("Choose conversion type: (1 or 2)");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        string? type = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Enter Celsius Temperature: ");
                double fahrenheitTemp = Conversion.CelsiusToFahrenheit(Console.ReadLine() ?? "0");
                Console.WriteLine($"Fahrenheit temperature is: {fahrenheitTemp}");
                break;
            case "2":
                Console.Write("Enter Fahrenheit Temperature: ");
                double celsiusTemp = Conversion.FahrenheitToCelsius(Console.ReadLine() ?? "0");
                Console.WriteLine($"Celsius temperature is: {celsiusTemp}");
                break;
            default:
                Console.WriteLine("Please select a convertor.");
                break;
        }

        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }

}