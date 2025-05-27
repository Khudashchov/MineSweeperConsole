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
    private Coordinates _currentCoordinates;
    private readonly Queue<Coordinates> _mines = new Queue<Coordinates>();
    private Random _random = new Random();
    private TimerLogic _timer = new TimerLogic();
    private StatsLogic _statsLogic = new StatsLogic();
    private StatsRecord _currentStat;

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

            if (state != GameState.InGame)
            {
                StopGame();

                switch (state)
                {
                    case GameState.Win:
                        DrawReport(Message.WinMessage);
                        SaveStat();
                        break;
                    case GameState.Loss:
                        DrawReport(Message.LossMessage);
                        break;
                    case GameState.Exit:
                        break;
                }
            }
            else
            {
                continue;
            }
        }
    }

    private Queue<Coordinates> GetMinePositions(int currentMines = 0)
    {
        while (currentMines < _mineCount)
        {
            _currentCoordinates.Y = _random.Next(0, Field.FieldHeight);
            _currentCoordinates.X = _random.Next(0, Field.FieldWidth);

            if (!_mines.Contains(_currentCoordinates))
            {
                _mines.Enqueue(_currentCoordinates);
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
        Console.Clear();

        DrawMessage(message);
        Cursor.SetCursorCenter(15, Console.WindowWidth, "Time: " + _timer.GetElapsedTime());
        Console.WriteLine("Time: " + _timer.GetElapsedTime());
        Cursor.SetCursorCenter(20, Console.WindowWidth, "Press any key to continue ...");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadLine();
        
        Cursor.SetDefaultColor();
    }
    public static void DrawMessage(string[] message)
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            for (int j = 0; j < Console.WindowWidth; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.Write(' ');
            }
        }
        for (int i = 0; i < message.Length; i++)
        {
            Cursor.SetCursorCenter(i + 5, Console.WindowWidth, message[i]);
            Console.WriteLine(message[i]);
        }
    }
    
    private void StopGame()
    {
        ProgramStatus.DisableGame();
        _timer.Stop();
    }

    private void SaveStat()
    {
        _currentStat = new StatsRecord(_timer.GetElapsedSeconds());
        _statsLogic.SaveRoundStats(_currentStat);
    }
}
