using MineSweeper.Interfaces;
using MineSweeper.Status;

namespace MineSweeper.Logic.Menu.Buttons;

public class ExitButton : IButton
{
    public void Action()
    {
        ProgramStatus.CloseProgram();

        Console.Clear();
    }
}