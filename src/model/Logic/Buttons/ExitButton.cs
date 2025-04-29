namespace Model.Logic.Buttons;

public class ExitButton : Button
{
    public override void Action()
    {
        ProgramStatus.DisableMenu();

        Console.Clear();
        
        ProgramStatus.CloseProgram();

    }
}