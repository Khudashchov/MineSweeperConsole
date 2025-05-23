using MineSweeper.Status;

namespace MineSweeper.Logic.Round;

public class Field
{
    public const int FieldHeight = 12;
    public const int FieldWidth = 22;
    private Cell[,] _field = new Cell[FieldHeight, FieldWidth];
    private readonly Queue<(int, int)> emptyCells = new Queue<(int, int)>();
    private int _currentLeft = 0;
    private int _currentTop = 0;
    private int _startY = Console.WindowHeight / 2;
    private int _startX = Console.WindowWidth / 2;
    private int _minesCount = 0;
    private int _currentOpened = 0;

    private int CurrentLeft
    {
        get => _currentLeft;
        set
        {
            if (value < 0)
            {
                _currentLeft = 0;
            }
            else if (value >= _field.GetLength(1))
            {
                _currentLeft = _field.GetLength(1) - 1;
            }
            else
            {
                _currentLeft = value;
            }
        }
    }

    private int CurrentTop
    {
        get => _currentTop;
        set
        {
            if (value < 0)
            {
                _currentTop = 0;
            }
            else if (value >= _field.GetLength(0))
            {
                _currentTop = _field.GetLength(0) - 1;
            }
            else
            {
                _currentTop = value;
            }
        }
    }

    public Field(int minesCount)
    {
        _minesCount = minesCount;
        FieldGenerate();
        DrawField();
    }

    private void FieldGenerate()
    {
        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                _field[i, j] = new Cell();
            }
        }
    }

    public void DrawCell(int top, int left)
    {
        Console.SetCursorPosition(_startX, _startY);
        Console.SetCursorPosition(Console.CursorLeft + left, Console.CursorTop + top);

        if (_field[top, left].IsOpen())
        {
            if (IsSelected(top, left))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
        }
        else
        {
            if (IsSelected(top, left))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
        }

        _field[top, left].PrintCell();
        Cursor.SetDefaultColor();
    }

    private void DrawField()
    {
        Console.SetCursorPosition(_startX, _startY);

        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                DrawCell(i, j);
            }

            Console.SetCursorPosition(Console.CursorLeft - _field.GetLength(1), Console.CursorTop + 1);
        }

        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - _field.GetLength(0));
    }


    public GameState MakeMove()
    {
        if (WinCondition())
        {
            return GameState.Win;
        }
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                DrawCell(CurrentTop--, CurrentLeft);
                break;
            case ConsoleKey.DownArrow:
                DrawCell(CurrentTop++, CurrentLeft);
                break;
            case ConsoleKey.RightArrow:
                DrawCell(CurrentTop, CurrentLeft++);
                break;
            case ConsoleKey.LeftArrow:
                DrawCell(CurrentTop, CurrentLeft--);
                break;
            case ConsoleKey.Enter:
                if (_field[CurrentTop, CurrentLeft].IsMine())
                {
                    _field[CurrentTop, CurrentLeft].Open();
                    DrawCell(CurrentTop, CurrentLeft);
                    return GameState.Loss;
                }

                emptyCells.Enqueue((CurrentTop, CurrentLeft));
                Open();

                break;
            case ConsoleKey.Escape:
                return GameState.Exit; 
        }

        DrawCell(CurrentTop, CurrentLeft);

        return GameState.InGame;
    }

    public void SetMines(Queue<Coordinates> mines)
    {
        while (mines.Count > 0)
        {
            var mine = mines.Dequeue();
            _field[mine.Y, mine.X].SetMine();
        }
    }

    public void SetNumbers()
    {
        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                if (!_field[i, j].IsMine())
                {
                    _field[i, j].CellValue = CountMinesCube(i, j);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    private int CountMinesCube(int y, int x)
    {
        int mines = 0;

        for (int i = y - 1; i < y + 2; i++)
        {
            for (int j = x - 1; j < x + 2; j++)
            {
                try
                {
                    if (_field[i, j].IsMine())
                    {
                        mines++;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }

        return mines;
    }

    private void Open()
    {
        while (emptyCells.Count > 0)
        {
            var coordinates = emptyCells.Dequeue();
            if (_field[coordinates.Item1, coordinates.Item2].IsOpen())
            {
                continue;
            }
            else
            {
                _field[coordinates.Item1, coordinates.Item2].Open();
                ++_currentOpened;
            }

            DrawCell(coordinates.Item1, coordinates.Item2);
            CheckArea(coordinates.Item1, coordinates.Item2);
        }
    }

    private void CheckArea(int coordinatesTop, int coordinatesLeft)
    {
        for (int i = coordinatesTop - 1; i < coordinatesTop + 2; i++)
        {
            for (int j = coordinatesLeft - 1; j < coordinatesLeft + 2; j++)
            {
                TryEnqueue(i, j);
            }
        }
    }

    private void TryEnqueue(int i, int j)
    {
        try
        {
            if (_field[i, j].IsOpen())
            {
                return;
            }
            else if (_field[i, j].IsEmpty())
            {
                emptyCells.Enqueue((i, j));
                DrawCell(i, j);
            }
            else if (!_field[i, j].IsMine())
            {
                _field[i, j].Open();
                ++_currentOpened;
                DrawCell(i, j);
            }
            else
            {
                return;
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }
    }

    private bool WinCondition()
    {
        return _currentOpened == (_field.GetLength(0) * _field.GetLength(1)) - _minesCount;
    }
    private bool IsSelected(int i, int j)
    {
        return CurrentLeft == j && CurrentTop == i;
    }
}