using System.Diagnostics;

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
ulong num = fib(number);
stopWatch.Stop();
Console.WriteLine($"Fibonacci number: {num}");
Console.WriteLine($"Time taken to calculate: {stopWatch.Elapsed}");
Console.WriteLine("Press any key to exit");
Console.ReadKey();

static ulong fib(int n)
{
    ulong n1 = 0;
    ulong n2 = 1;
    ulong sum;

    for (int i = 2; i <= n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
    }

    return n == 0 ? n1 : n2;
}
