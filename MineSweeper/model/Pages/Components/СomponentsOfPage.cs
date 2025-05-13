using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Logic;

namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfPage : IComponentsOfPage, IDisposable
{
    private bool _IsDisposed = false;
    private string[] _mineSweeperName = 
    {
        "███╗░░░███╗██╗███╗░░██╗███████╗░██████╗░██╗░░░░░░░██╗███████╗███████╗██████╗░███████╗██████╗░", // 93 symbols
        "████╗░████║██║████╗░██║██╔════╝██╔════╝░██║░░██╗░░██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗",
        "██╔████╔██║██║██╔██╗██║█████╗░░╚█████╗░░╚██╗████╗██╔╝█████╗░░█████╗░░██████╔╝█████╗░░██████╔╝",
        "██║╚██╔╝██║██║██║╚████║██╔══╝░░░╚═══██╗░░████╔═████║░██╔══╝░░██╔══╝░░██╔═══╝░██╔══╝░░██╔══██╗",
        "██║░╚═╝░██║██║██║░╚███║███████╗██████╔╝░░╚██╔╝░╚██╔╝░███████╗███████╗██║░░░░░███████╗██║░░██║",
        "╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝"
    };

    public void SetHeader()
    {
        Cursor.SetDefaultColor();
        SetMenuName();
        SetHorizontalBorder();
    }

    public void SetBody()
    {
        SetBodyBorders();
        SetBodyComponents();
    }

    protected virtual void SetBodyComponents()
    {   
        Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight / 2);
        Console.Write("This is empty page!");
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1);  
    }

    protected void SetBodyBorders()
    {
        int CurrentTop = Console.CursorTop;

        SetVerticalBorder("left", CurrentTop);
        SetVerticalBorder("right", CurrentTop);

        SetHorizontalBorder();
    }

    private void SetVerticalBorder(string side, int currentTop)
    {
        int Cursor = 0;

        side = side.ToUpper();

        if(side == "RIGHT")
        {
            Cursor = Console.WindowWidth - 1;
        } else if(side == "LEFT")   
        {
            Cursor = Console.WindowLeft;
        } else 
        {
            Console.WriteLine("Incorrect parametr");
            return;
        }

        for(int i = currentTop; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(Cursor, i);
            Console.Write("|");
            Console.WriteLine();
        }
    }

    private void SetHorizontalBorder()
    {
        Console.Write("+");
        for(int i = 0; i < Console.WindowWidth - 2; i++)
        {
            Console.Write("-");
        }
        Console.Write("+");
        Console.WriteLine();
    }

    private void SetMenuName()
    {
        for(int i = 0; i < _mineSweeperName.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Cursor.SetCursorCenter(Console.CursorTop, Console.WindowWidth, _mineSweeperName[0]);

            Console.WriteLine($" {_mineSweeperName[i]}");

            Cursor.SetDefaultColor();
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(!_IsDisposed)
        {
            _IsDisposed = true;

            if(disposing)
            {
                
            }
        }
    }

    ~ComponentsOfPage()
    {
        Dispose(false);
    }
}