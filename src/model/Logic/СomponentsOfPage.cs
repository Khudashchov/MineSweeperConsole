using Model.Interfaces;

public class СomponentsOfPage : IСomponentsOfPage, IDisposable
{
    private bool _IsDisposed = false;
    protected Cursor _cursor = new Cursor();
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
        SetDefaultColor();
        SetMenuName();
        SetHorizontalBorder();
    }

    public void SetBody()
    {
        SetBodyBorders();
        SetBodyComponents();
    }

    public virtual void SetBodyComponents()
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

    private void SetVerticalBorder(string side, int CurrentTop)
    {
        int Cursor = 0;
        side = side.ToUpper();
        if(side == "RIGHT")
        {
            Cursor = Console.WindowWidth + 1;
        } else if(side == "LEFT")
        {
            Cursor = Console.WindowLeft;
        } else 
        {
            Console.WriteLine("Incorrect parametr");
            return;
        }

        for(int i = CurrentTop; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(Cursor, i);
            Console.Write("|");
        }
    }

    private void SetHorizontalBorder()
    {
        Console.Write("+");
        for(int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("+");
    }

    private void SetMenuName()
    {
        for(int i = 0; i < _mineSweeperName.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            _cursor.SetCursorCenter(Console.CursorTop, Console.WindowWidth, _mineSweeperName[0]);

            Console.Write($" {_mineSweeperName[i]}");

            SetDefaultColor();
            Console.WriteLine();
        }
    }
    protected void SetDefaultColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
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
                _cursor.Dispose();
            }
        }
    }

    ~СomponentsOfPage()
    {
        Dispose(false);
    }
}