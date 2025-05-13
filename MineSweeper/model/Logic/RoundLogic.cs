using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Logic.Round;

namespace MineSweeper.Model.Logic;

public class RoundLogic : IRoundLogic
{
    private Field _field;
    private Stack<(int, int)> _mines = new Stack<(int, int)>();
    private Random _random = new Random();
    public RoundLogic(int mineCount)
    {
        _mines = new Stack<(int, int)>(mineCount);
        _field = new Field();
    }
    public void Generate()
    {   
        _field.SetMines(GetMines());
        _field.SelectCell();
    }

    private Stack<(int, int)> GetMines()
    {
        int currentMines = 0;
        while (currentMines < _mines.Count)
        {
            int x = _random.Next(0, _field.GetFieldX());
            int y = _random.Next(0, _field.GetFieldY());
            // if (!_field.IsMine(x, y))
            // {
                _mines.Push((x, y));
                currentMines++;
            // }
        }

        return _mines;
    }
}
