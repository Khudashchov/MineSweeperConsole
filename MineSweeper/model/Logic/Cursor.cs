using MineSweeper.Model.Pages.Components;

namespace MineSweeper.Model.Logic;

public static class Cursor
{
    public static void SetCursorCenter(int top, int width, string value)
    {
        using (ComponentsOfPage name = new ComponentsOfPage())
        {
            Console.SetCursorPosition((width / 2) - (value.Length / 2), top);
        }
    }

    public static void SetDefaultColor()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.Black;
    }
}