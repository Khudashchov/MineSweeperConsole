using MineSweeper.Interfaces;
using MineSweeper.Logic.Round;
using MineSweeper.Status;
using MineSweeper.Messages;
using MineSweeper.Logic.Stats;

namespace MineSweeper.Logic;

public class RoundLogic : IRoundLogic
{
    private int _mineCount;
    private Field _field;
    private Stack<(int, int)> _mines = new Stack<(int, int)>();
    private Random _random = new Random();
    private TimerLogic _timer = new TimerLogic();
    private StatsLogic _statsLogic = new StatsLogic();

    public RoundLogic(int mineCount)
    {
        _mineCount = mineCount;
        _field = new Field(mineCount);
    }

    public void Generate()
    {
        GenerateFieldValues();
        _timer.Start();

        while (ProgramStatus.GetGameStatus())
        {
            GameState state = _field.MakeMove();
            
            switch (state)
            {
                case GameState.Win:
                    DrawReport(Message.WinMessage);
                    StatsRecord stats = new StatsRecord(_timer.GetElapsedSeconds());
                    _statsLogic.SaveRoundStats(stats);
                    break;
                case GameState.Loss:
                    DrawReport(Message.LossMessage);
                    break;
                case GameState.Exit:
                    _timer.Stop();
                    break;
                default:
                    continue;
            }
        }
    }

    private Stack<(int, int)> GetMinePositions()
    {
        int currentMines = 0;
        while (currentMines < _mineCount)
        {
            int top = _random.Next(0, _field.GetFieldHeight());
            int left = _random.Next(0, _field.GetFieldWidth());
            if (!_field.IsMine(top, left))
            {
                _mines.Push((top, left));
                currentMines++;
            }
        }

        return _mines;
    }

    private void GenerateFieldValues()
    {
        _field.SetMines(GetMinePositions());
        _field.SetNumbers();
    }

    private void DrawReport(string[] message)
    {
        ProgramStatus.DisableGame();
        _timer.Stop();
        Console.Clear();
        Message.DrawMessage(message);
        Cursor.SetCursorCenter(15, Console.WindowWidth, "Time: " + _timer.GetElapsedTime());
        Console.WriteLine("Time: " + _timer.GetElapsedTime());
        Cursor.SetCursorCenter(20, Console.WindowWidth, "Press any key to continue ...");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadLine();
        Cursor.SetDefaultColor();
    }
}
