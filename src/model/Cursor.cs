public class Cursor
{
    private bool _IsDisposed = false;
    public void SetCursorCenter(int top)
    {
        MenuComponents name = new MenuComponents();

        Console.SetCursorPosition((Console.WindowWidth / 2) - (name.GetNameLength() / 2), top);

        name.Dispose();
        
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

    ~Cursor()
    {
        Dispose(false);
    }
}