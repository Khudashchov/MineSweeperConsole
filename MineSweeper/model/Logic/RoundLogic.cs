using MineSweeper.Model.Interfaces;

namespace MineSweeper.Model.Logic;

public class RoundLogic : IRoundLogic
{
    private Cell[,] _field = new Cell[32,48];
    private int _currentX;
    private int _currentY;

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
    public void Generate()
    {
        FieldGenerate();
        SelectCellLogic();

    }

    private void DrawField()
    {
        Console.SetCursorPosition((Console.WindowWidth - 48) /2, (Console.WindowHeight- 32) / 2);

        for(int i = 0; i < _field.GetLength(0); i++)
        {
            for(int j = 0; j < _field.GetLength(1); j++)
            {
                DrawCell(i,j);
            }
            
            Console.SetCursorPosition(Console.CursorLeft - _field.GetLength(1), Console.CursorTop + 1);
        }

        Console.SetCursorPosition(Console.CursorLeft + CurrentX, Console.CursorTop - _field.GetLength(0) + CurrentY);
    }

    private void DrawCell(int i, int j)
    {
        
        if(_field[i,j].IsOpen())
        {
            if(IsSelected(i,j))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            } else 
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
            }

            Console.Write($"{_field[i,j].CellValue}");
        } else 
        {
            if(IsSelected(i,j))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            } else 
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }

            Console.Write(" ");
        }

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

    private void SelectCellLogic()
    {
        Console.CursorVisible = false;

        CurrentX = 0;
        CurrentY = 0;

        DrawField();

        while(ProgramStatus.GetGameStatus())
        {
            DrawField();

            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    CurrentY--;
                    break;
                case ConsoleKey.DownArrow:
                    CurrentY++;
                    break;
                case ConsoleKey.RightArrow:
                    CurrentX++;
                    break;
                case ConsoleKey.LeftArrow:
                    CurrentX--;
                    break;
                case ConsoleKey.Enter:
                    ProgramStatus.DisableGame();
                    break;
                    
            }
        }
    }

    private bool IsSelected(int i, int j)
    {
        return CurrentX == j && CurrentY == i;
    }
}
