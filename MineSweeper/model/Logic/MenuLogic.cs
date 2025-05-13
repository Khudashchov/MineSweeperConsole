using MineSweeper.Model.Abstracts;
using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Logic;

public class MenuLogic : IMenuLogic
{
    private int _cursorCentrePos = Console.WindowHeight / 2;
    private short _taskMaxValue;
    private short _taskValue;
    private short _task
    {
        get
        {
            return _taskValue;
        }
        set
        {
                if(value > _taskMaxValue)
                {
                    _taskValue = _taskMaxValue;
                } else if(value < 0)
                {
                    _taskValue = 0;
                } else
                {
                    _taskValue = value;
                }
        }
    }
    
    
    private void DrawTasks(Dictionary<string, ButtonBase> functions, List<string> keys)
    {
        for(int i = 0; i < functions.Count; i++)
        {
            Cursor.SetCursorCenter(_cursorCentrePos + (i * 3), Console.WindowWidth - 2, keys[i]);

            if(i == _task)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write($">>> {keys[i]} <<<");
            } else 
            {
                Console.Write($"    {keys[i]}    ");
            }

            Cursor.SetDefaultColor();  

        }
    }

    public void SelectOption(Dictionary<string, ButtonBase> functions)
    {
        ProgramStatus.EnableMenu();
        Console.CursorVisible = false;

        var keys = new List<string>(functions.Keys);
        _taskMaxValue = Convert.ToInt16(functions.Count - 1);
        _task = 0;

        while(ProgramStatus.GetMenuStatus())
        {
            DrawTasks(functions, keys);

            Console.SetCursorPosition(Console.CursorLeft, 0);

            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    _task--;
                    break;
                case ConsoleKey.DownArrow:
                    _task++;
                    break;
                case ConsoleKey.Enter:
                    functions.TryGetValue(keys[_task], out ButtonBase button);
                    button.Action();
                    break;
            }
        }
    }
}