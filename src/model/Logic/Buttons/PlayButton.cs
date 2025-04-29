namespace Model.Logic.Buttons;

public class PlayButton : Button
{
    PageRound Round = new PageRound();
    public override void Action()
    {
        ProgramStatus.DisableMenu();
        
        Round.GenerateRound();
        Console.ReadLine();
    }
}