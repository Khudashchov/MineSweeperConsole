namespace MineSweeper.Model.Logic.Round;

public class Field
{
    private Cell[,] _field = new Cell[33,48];
    private int _currentX;
    private int _currentY;
    private int StartX = (Console.WindowWidth - 48) /2;
    private int StartY = (Console.WindowHeight- 32) / 2;

    private int CurrentX{
        get
        {
            return _currentX;
        }
        set
        {
            if(value < 0)
            {
                _currentX = 0;
            } else if(value >= _field.GetLength(1))
            {
                _currentX = _field.GetLength(1) - 1;
            } else
            {
                _currentX = value;
            }
        }
    }

    private int CurrentY{
        get
        {
            return _currentY;
        }
        set
        {
            if(value < 0)
            {
                _currentY = 0;
            } else if(value >= _field.GetLength(0))
            {
                _currentY = _field.GetLength(0) - 1;
            } else
            {
                _currentY = value;
            }
        }
    }

    public Field()
    {
        FieldGenerate();
    }

    private void DrawField()
    {
        Console.SetCursorPosition(StartX, StartY);

        for(int i = 0; i < _field.GetLength(0); i++)
        {
            for(int j = 0; j < _field.GetLength(1); j++)
            {
                DrawCell(i,j);
            }
            
            Console.SetCursorPosition(Console.CursorLeft - _field.GetLength(1), Console.CursorTop + 1);
        }

        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - _field.GetLength(0));
    }

    public void DrawCell(int Top, int Left)
    {
        Console.SetCursorPosition(StartX, StartY);
        Console.SetCursorPosition(Console.CursorLeft + Left, Console.CursorTop + Top);

        if(_field[Top,Left].IsOpen())
        {
            if(IsSelected(Top,Left))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            } else 
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
        } else 
        {
            if(IsSelected(Top,Left))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            } else 
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
        }

        _field[Top,Left].PrintCell();
        Cursor.SetDefaultColor();
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

    public void SelectCell()
    {
        Console.CursorVisible = false;

        CurrentX = 0;
        CurrentY = 0;

        DrawField();

        while(ProgramStatus.GetGameStatus())
        {
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    DrawCell(CurrentY--, CurrentX);
                    break;
                case ConsoleKey.DownArrow:
                    DrawCell(CurrentY++, CurrentX);
                    break;
                case ConsoleKey.RightArrow:
                    DrawCell(CurrentY, CurrentX++);
                    break;
                case ConsoleKey.LeftArrow:
                    DrawCell(CurrentY, CurrentX--);
                    break;
                case ConsoleKey.Enter:
                    _field[CurrentY, CurrentX].Open();
                    DrawCell(CurrentY, CurrentX);
                    break;
                case ConsoleKey.Escape:
                    ProgramStatus.DisableGame();
                    break;
            }

            DrawCell(CurrentY, CurrentX);
        }
    }

    public void SetMines(Stack<(int, int)> mines)
    {
        while(mines.Count > 0)
        {
            var mine = mines.Pop();
            _field[mine.Item1, mine.Item2].SetMine();
        }
    }

    private bool IsSelected(int i, int j)
    {
        return CurrentX == j && CurrentY == i;
    }

    public int GetFieldY() => _field.GetLength(0);

    public int GetFieldX() => _field.GetLength(1);
}