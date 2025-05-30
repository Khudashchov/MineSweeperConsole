using MineSweeper.Interfaces;
using MineSweeper.Status;

namespace MineSweeper.Logic;

public class MenuLogic : IMenuLogic
{
    private short _taskMaxValue;
    private short _taskValue;
    private short _task
    {
        get => _taskValue;
        set
        {
            if (value > _taskMaxValue)
            {
                _taskValue = _taskMaxValue;
            }
            else if (value < 0)
            {
                _taskValue = 0;
            }
            else
            {
                _taskValue = value;
            }
        }
    }

    public MenuLogic()
    {
        ProgramStatus.EnableMenu();
    }

    private void DrawTasks(Dictionary<string, IButton> functions, List<string> keys)
    {
        for (int i = 0; i < functions.Count; i++)
        {
            Cursor.SetCursorCenter((Console.WindowHeight / 2) + (i * 3), Console.WindowWidth - 2, keys[i]);

            if (i == _task)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write($">>> {keys[i]} <<<");
            }
            else
            {
                Console.Write($"    {keys[i]}    ");
            }

            Cursor.SetDefaultColor();

        }
    }

    public IButton SelectOption(Dictionary<string, IButton> functions)
    {
        var keys = new List<string>(functions.Keys);
        _taskMaxValue = Convert.ToInt16(functions.Count - 1);
        _task = 0;

        while (ProgramStatus.GetMenuStatus())
        {
            DrawTasks(functions, keys);

            Console.SetCursorPosition(Console.CursorLeft, 0);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    _task--;
                    break;
                case ConsoleKey.DownArrow:
                    _task++;
                    break;
                case ConsoleKey.Enter:
                    ProgramStatus.DisableMenu();
                    break;
            }
        }
#pragma warning disable CS8600
#pragma warning disable CS8603
        functions.TryGetValue(keys[_task], out IButton button);

        return button;
#pragma warning restore CS8600
#pragma warning restore CS8603
    }
}