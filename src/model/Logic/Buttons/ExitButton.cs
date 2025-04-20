public class ExitButton : Button
{
    public override void Action()
    {
        ProgramStatus.IsMenuRunning = false;

        Console.Clear();
        ProgramStatus.IsRunning = false;

    }
}