namespace Model.Logic.Buttons;

public class PlayButton : Button
{
    PageRound Round = new PageRound();
    public override void Action()
    {
        ProgramStatus.DisableMenu();
        ProgramStatus.EnableGame();

        Round.Generate();
    }
}