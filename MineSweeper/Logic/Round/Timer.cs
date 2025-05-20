namespace MineSweeper.Logic.Round;

public class TimerLogic
{
    private int _seconds;
    private bool _running;
    private Thread _timerThread;

    public void Start()
    {
        _running = true;
        _timerThread = new Thread(RunTimer);
        _timerThread.IsBackground = true;
        _timerThread.Start();
    }

    public void Stop()
    {
        _running = false;
        _timerThread.Join();
    }

    public string GetElapsedTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(_seconds);
        return $"{time.Minutes:D2}:{time.Seconds:D2}";
    }

    public int GetElapsedSeconds()
    {
        return _seconds;
    }

    private void RunTimer()
    {
        while (_running)
        {
            Console.SetCursorPosition(3, Console.WindowHeight / 2 + 5);
            Console.Write($"Таймер: {GetElapsedTime()}");
            _seconds++;
            Thread.Sleep(1000);
        }
    }
}