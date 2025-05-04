using MineSweeper.Model.Abstracts;

namespace MineSweeper.Model.Logic.Buttons;

public class ExitButton : ButtonBase
{
    public override void Action()
    {
        ProgramStatus.DisableMenu();

        Console.Clear();
        
        ProgramStatus.CloseProgram();

    }
}