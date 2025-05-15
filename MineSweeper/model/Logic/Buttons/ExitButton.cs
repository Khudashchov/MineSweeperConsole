using MineSweeper.Model.Interfaces;

namespace MineSweeper.Model.Logic.Buttons;

public class ExitButton : IButton
{
    public void Action()
    {
        Console.Clear();
        
        ProgramStatus.CloseProgram();
    }
}