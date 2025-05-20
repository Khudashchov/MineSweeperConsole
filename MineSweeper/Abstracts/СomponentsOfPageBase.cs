using MineSweeper.Logic;
using MineSweeper.Messages;

namespace MineSweeper.Abstracts;

public abstract class ComponentsOfPageBase
{
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

    protected abstract void SetBodyComponents();

    protected void SetBodyBorders()
    {
        int currentTop = Console.CursorTop;

        SetVerticalBorder("left", currentTop);
        SetVerticalBorder("right", currentTop);

        SetHorizontalBorder();
    }

    private void SetVerticalBorder(string side, int currentTop)
    {
        int cursor = 0;

        side = side.ToUpper();

        if (side == "RIGHT")
        {
            cursor = Console.WindowWidth - 1;
        }
        else if (side == "LEFT")
        {
            cursor = Console.WindowLeft;
        }
        else
        {
            Console.WriteLine("Incorrect parametr");
            return;
        }

        for (int i = currentTop; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(cursor, i);
            Console.Write("|");
            Console.WriteLine();
        }
    }

    private void SetHorizontalBorder()
    {
        Console.Write("+");
        for (int i = 0; i < Console.WindowWidth - 2; i++)
        {
            Console.Write("-");
        }
        Console.Write("+");
        Console.WriteLine();
    }

    private void SetMenuName()
    {
        for (int i = 0; i < Message.MineSweeperName.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Cursor.SetCursorCenter(Console.CursorTop, Console.WindowWidth, Message.MineSweeperName[0]);

            Console.WriteLine($" {Message.MineSweeperName[i]}");

            Cursor.SetDefaultColor();
        }
    }
}