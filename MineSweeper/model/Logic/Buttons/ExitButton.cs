using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Status;

namespace MineSweeper.Model.Logic.Buttons;

public class ExitButton : IButton
{
    public void Action()
    {
        Console.Clear();

        ProgramStatus.CloseProgram();
    }
}