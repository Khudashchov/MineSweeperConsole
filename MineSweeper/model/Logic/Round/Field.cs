using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MineSweeper.Model.Logic.Round;

public class Field
{
    private Cell[,] _field = new Cell[32, 48];
    private Queue<(int, int)> emptyCells = new Queue<(int, int)>();
    private int _currentLeft;
    private int _currentTop;
    private int StartX = (Console.WindowWidth - 48) /2;
    private int StartY = (Console.WindowHeight- 24) / 2;
    private int _minesCount = 0;
    private int _currentOpened = 0;
    private string[] _winMessage = {
        "██╗    ██╗██╗███╗   ██╗██╗",
        "██║    ██║██║████╗  ██║██║",
        "██║ █╗ ██║██║██╔██╗ ██║██║",
        "██║███╗██║██║██║╚██╗██║╚═╝",
        "╚███╔███╔╝██║██║ ╚████║██╗",
        " ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝"
    };
    private string[] _lossMessage = {
        "██╗      ██████╗ ███████╗███████╗██╗",
        "██║     ██╔═══██╗██╔════╝██╔════╝██║",
        "██║     ██║   ██║███████╗███████╗██║",
        "██║     ██║   ██║╚════██║╚════██║╚═╝",
        "███████╗╚██████╔╝███████║███████║██╗",
        "╚══════╝ ╚═════╝ ╚══════╝╚══════╝╚═╝"
    };
    private int CurrentLeft{
        get
        {
            return _currentLeft;
        }
        set
        {
            if(value < 0)
            {
                _currentLeft = 0;
            } else if(value >= _field.GetLength(1))
            {
                _currentLeft = _field.GetLength(1) - 1;
            } else
            {
                _currentLeft = value;
            }
        }
    }

    private int CurrentTop{
        get
        {
            return _currentTop;
        }
        set
        {
            if(value < 0)
            {
                _currentTop = 0;
            } else if(value >= _field.GetLength(0))
            {
                _currentTop = _field.GetLength(0) - 1;
            } else
            {
                _currentTop = value;
            }
        }
    }

    public Field(int minesCount)
    {
        _minesCount = minesCount;
        FieldGenerate();
        SetFieldConfig();
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

    private void SetFieldConfig()
    {
        Console.CursorVisible = false;

        CurrentLeft = 0;
        CurrentTop = 0;
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

    private void DrawMessage(string[] message)
    {
        for(int i =0; i < _field.GetLength(0); i++)
        {
            for(int j = 0; j < _field.GetLength(1); j++)
            {
                Console.SetCursorPosition(StartX + j, StartY + i);
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.Write(' '); 
            }
        }
        for(int i = 0; i < message.Length; i++)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - 17, (Console.WindowHeight / 2) + i);
            Console.WriteLine(message[i]);
        }

    }
    public void MakeMove()
    {
        if(WinCondition())
        {
            ProgramStatus.DisableGame();
            DrawMessage(_winMessage);
            Console.ReadLine();
            Cursor.SetDefaultColor();
            return;
        }
        switch(Console.ReadKey(true).Key)
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
                if(_field[CurrentTop, CurrentLeft].IsMine())
                {
                    ProgramStatus.DisableGame();
                    _field[CurrentTop, CurrentLeft].Open();
                    DrawCell(CurrentTop, CurrentLeft);
                    DrawMessage(_lossMessage);
                    Console.ReadLine();
                    break;
                }

                emptyCells.Enqueue((CurrentTop, CurrentLeft));
                Open();
                

                break;
            case ConsoleKey.Escape:
                ProgramStatus.DisableGame();
                break;
        }

        DrawCell(CurrentTop, CurrentLeft);  
    }

    public void SetMines(Stack<(int, int)> mines)
    {
        while(mines.Count > 0)
        {
            var mine = mines.Pop();
            _field[mine.Item1, mine.Item2].SetMine();
        }
    }

    public void SetNumbers()
    {   
        for (int i = 0; i < _field.GetLength(0); i++)
        {
            for (int j = 0; j < _field.GetLength(1); j++)
            {
                if(!_field[i, j].IsMine())
                {
                    _field[i,j].CellValue = CountMinesCube(i, j);
                } else
                {
                    continue;
                }
            }
        }
    }

    private int CountMinesCube(int Y, int X)
    {
        int mines = 0;

        for (int i = Y - 1; i < Y + 2; i++)
        {
            for (int j = X - 1; j < X + 2; j++)
            {
                try
                {
                    if(_field[i, j].IsMine())
                    {
                        mines++;
                    } else
                    {
                        continue;
                    }
                } catch (ArgumentOutOfRangeException)
                {
                    continue;
                } catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }

        return mines;
    }

    private void Open()
    {
        while(emptyCells.Count > 0)
        {
            var coordinates = emptyCells.Dequeue();
            if (_field[coordinates.Item1, coordinates.Item2].IsOpen())
            {   
                continue;
            } else 
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
        for(int i = coordinatesTop - 1; i < coordinatesTop + 2; i++)
        {
            for(int j = coordinatesLeft - 1; j < coordinatesLeft + 2; j++)
            {
                TryEnqueue(i, j);
            }
        }
    }

    private void TryEnqueue(int i,  int j)
    {
        try
        {
            if(_field[i, j].IsOpen())
            {
                return;
            } else if(_field[i, j].IsEmpty())
            {
                emptyCells.Enqueue((i, j));
                DrawCell(i, j);
            } else if(!_field[i, j].IsMine())
            {
                _field[i, j].Open();
                ++_currentOpened;
                DrawCell(i, j);
            } else 
            {
                return;
            }
        } catch (ArgumentOutOfRangeException)
        {
            return;
        } catch (IndexOutOfRangeException)
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

    public bool IsMine(int i, int j)
    {
        return _field[i,j].IsMine();
    }

    public int GetFieldHeight() => _field.GetLength(0);

    public int GetFieldWidth() => _field.GetLength(1);
}