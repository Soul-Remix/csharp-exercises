using static System.Math;
namespace Teleprompter;
internal class TeleConfig
{
    public int Delay { get; set; } = 200;
    public bool Done { get; set; } = false;

    public void UpdateDelay(int inc)
    {
        int newDelay = Min(Delay + inc, 1000);
        newDelay = Max(newDelay, 20);
        Delay = newDelay;
    }
    public void setDone()
    {
        Done = true;
    }
}