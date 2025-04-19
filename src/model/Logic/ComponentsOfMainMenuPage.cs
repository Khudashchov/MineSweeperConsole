public class ComponentsOfMainMenuPage : СomponentsOfPage
{
    private int _cursorCentrePos = Console.WindowHeight / 2;
    private int _cursorCurrentPos;
    private bool _ProgramStatus = true;
    private PageRound Game = new PageRound();
    private short _taskValue;
    private short _task
    {
        get
        {
            return _taskValue;
        }
        set
        {
                if(value > 2)
                {
                    _taskValue = 2;
                } else if(value < 0)
                {
                    _taskValue = 0;
                } else
                {
                    _taskValue = value;
                }
        }
    }
    string[] Functions = {
        "PLAY",
        "STATS",
        "EXIT"
    };
    public override void SetBodyComponents()
    {
        _task = 0;
        Console.CursorVisible = false;
        SelectOption();
    }
    private void DrawTasks()
    {

        for(int i = 0; i < Functions.Length; i++)
        {
            if(i == _task)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                _cursorCurrentPos = Console.CursorTop;
            }
            _cursor.SetCursorCenter(_cursorCentrePos + (i * 3), Console.WindowWidth - 2, Functions[i]);
            Console.Write(Functions[i]);
            SetDefaultColor();  
        }
    }

    private void SelectOption()
    {
        while(_ProgramStatus)
        {
            DrawTasks();
            Console.SetCursorPosition(Console.CursorLeft, _cursorCurrentPos);
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    _task--;
                    break;
                case ConsoleKey.DownArrow:
                    _task++;
                    break;
                case ConsoleKey.Enter:
                    switch(_task)
                    {
                        case 0:
                            Console.Clear();
                            Game.GenerateRound();
                            Console.ReadKey();
                            break;
                        case 1: Console.WriteLine("Empty here.");
                            Console.ReadKey();
                            break;
                        case 2: _ProgramStatus = false; 
                            break;
                    }
                    break;
            }
        }
    }
}