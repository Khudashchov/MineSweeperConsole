namespace Model.Logic.Buttons;

public class StatsButton : Button
{
    PageStats Stats = new PageStats();

    public override void Action()
    {
        ProgramStatus.DisableMenu();

        Stats.Generate();
        Console.ReadLine();
    }
}