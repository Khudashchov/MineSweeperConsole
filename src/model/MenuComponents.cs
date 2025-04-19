using Model.Interfaces;
public class MenuComponents : IMenuComponents, IDisposable
{
    private bool _IsDisposed = false;
    private Cursor _cursor = new Cursor();
    private string[] _mineSweeperName = 
    {
        "███╗░░░███╗██╗███╗░░██╗███████╗░██████╗░██╗░░░░░░░██╗███████╗███████╗██████╗░███████╗██████╗░", // 93 symbols
        "████╗░████║██║████╗░██║██╔════╝██╔════╝░██║░░██╗░░██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗",
        "██╔████╔██║██║██╔██╗██║█████╗░░╚█████╗░░╚██╗████╗██╔╝█████╗░░█████╗░░██████╔╝█████╗░░██████╔╝",
        "██║╚██╔╝██║██║██║╚████║██╔══╝░░░╚═══██╗░░████╔═████║░██╔══╝░░██╔══╝░░██╔═══╝░██╔══╝░░██╔══██╗",
        "██║░╚═╝░██║██║██║░╚███║███████╗██████╔╝░░╚██╔╝░╚██╔╝░███████╗███████╗██║░░░░░███████╗██║░░██║",
        "╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝"
    };

    public void GenerateMenu()
    {
        SetDefaultColor();
        SetMenuName();
        SetHorizontalBorder();
    }

    public void SetHorizontalBorder()
    {
        Console.Write("+");
        for(int i = 0; i < Console.WindowWidth; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("+");
    }
    
    public void SetMenuName()
    {
        for(int i = 0; i < _mineSweeperName.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            _cursor.SetCursorCenter(Console.CursorTop);

            Console.Write($" {_mineSweeperName[i]}");

            SetDefaultColor();
            Console.WriteLine();
        }
    }
    public void SetDefaultColor()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public int GetNameLength()
    {
        return _mineSweeperName[0].Length;
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

    ~MenuComponents()
    {
        Dispose(false);
    }
}