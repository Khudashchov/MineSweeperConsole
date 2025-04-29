namespace Model.Logic.Buttons;

public class StatsButton : Button
{
    public override void Action()
    {
        ProgramStatus.DisableMenu();
        
        Console.WriteLine("Empty here.");
    }
}