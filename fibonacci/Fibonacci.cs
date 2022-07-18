namespace Utility;

static class Fibonacci
{
    private static Dictionary<int, ulong> hashMap = new Dictionary<int, ulong>();


    public static ulong FibIter(int n)
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

    public static ulong FibRec(int n)
    {
        if (n < 2)
        {
            return (ulong)n;
        }
        ulong fibNum;
        if (hashMap.TryGetValue(n, out fibNum))
        {
            return fibNum;
        }
        fibNum = FibRec(n - 1) + FibRec(n - 2);
        hashMap.Add(n, fibNum);
        return fibNum;
    }
}