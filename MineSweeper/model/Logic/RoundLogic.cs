using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Logic.Round;
using MineSweeper.Model.Status;
using MineSweeper.Model.Messages;

namespace MineSweeper.Model.Logic;

public class RoundLogic : IRoundLogic
{
    private int _mineCount;
    private Field _field;
    private Stack<(int, int)> _mines = new Stack<(int, int)>();
    private Random _random = new Random();

    public RoundLogic(int mineCount)
    {
        _mineCount = mineCount;
        _field = new Field(mineCount);
    }

    public void Generate()
    {
        GenerateFieldValues();
        while (ProgramStatus.GetGameStatus())
        {
            GameState state = _field.MakeMove();

            if (state == GameState.Win)
            {
                DrawReport(Message.WinMessage);

            }
            else if (state == GameState.Loss)
            {
                DrawReport(Message.LossMessage);
            }
            else
            {
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
        Console.Clear();
        Message.DrawMessage(message);
        Console.ReadLine();
        Cursor.SetDefaultColor();
    }
}
