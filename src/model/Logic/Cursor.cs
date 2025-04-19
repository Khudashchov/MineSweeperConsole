public class Cursor
{
    private bool _IsDisposed = false;

    public void SetCursorCenter(int top, int width, string item)
    {
        СomponentsOfPage name = new СomponentsOfPage();

        Console.SetCursorPosition((width / 2) - (item.Length / 2), top);

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