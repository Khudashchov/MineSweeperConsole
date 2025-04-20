public class PlayButton : Button
{
    PageRound Round = new PageRound();
    public override void Action()
    {
        ProgramStatus.IsMenuRunning = false;
        
        Round.GenerateRound();
        Console.ReadLine();
    }
}