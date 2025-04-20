public static class Cursor
{
    public static void SetCursorCenter(int top, int width, string item)
    {
        СomponentsOfPage name = new СomponentsOfPage();

        Console.SetCursorPosition((width / 2) - (item.Length / 2), top);

        name.Dispose();
        
    }

    public static void SetDefaultColor()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}