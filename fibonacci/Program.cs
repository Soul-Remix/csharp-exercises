using System.Diagnostics;
using Utility;

Console.WriteLine("1. iterator");
Console.WriteLine("2. Recursive");
Console.Write("Choose recursive or iterator function: ");
string? type = Console.ReadLine();

if (type != "1" && type != "2")
{
    Console.WriteLine("You should only choose from (1 or 2)");
    return;
}

int number;
do
{
    Console.Write("Enter an integer number to calculate fibonacci: ");
    string? numberInput = Console.ReadLine();

    if (int.TryParse(numberInput, out number))
    {
        break;
    }
    else
    {
        Console.WriteLine("Input need to be a valid integer");
        continue;
    }
} while (true);

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

ulong fibNum;
switch (type)
{
    case "1":
        fibNum = Fibonacci.FibIter(number);
        Console.WriteLine($"Fibonacci number: {fibNum}");
        break;
    case "2":
        fibNum = Fibonacci.FibRec(number);
        Console.WriteLine($"Fibonacci number: {fibNum}");
        break;
}

stopWatch.Stop();
Console.WriteLine($"Time taken to calculate: {stopWatch.Elapsed}");
Console.WriteLine("Press any key to exit");
Console.ReadKey();