namespace TempConversion;

class Conversion
{
    public static double CelsiusToFahrenheit(string temperatureCelsius)
    {
        double celsius = Double.Parse(temperatureCelsius);
        double fahrenheit = (celsius * 9 / 5) + 32;
        return fahrenheit;
    }

    public static double FahrenheitToCelsius(string temperatureFahrenheit)
    {
        double fahrenheit = Double.Parse(temperatureFahrenheit);
        double celsius = (fahrenheit - 32) * 5 / 9;
        return celsius;
    }
}