using MineSweeper.Interfaces;
using MineSweeper.Status;

namespace MineSweeper.Logic.Buttons;

public class ExitButton : IButton
{
    public void Action()
    {
        Console.Clear();

        ProgramStatus.CloseProgram();
    }
}