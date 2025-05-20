using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Pages;
using MineSweeper.Model.Status;

namespace MineSweeper.Model.Logic.Buttons;

public class PlayButton : IButton
{
    PageRound Round = new PageRound();
    public void Action()
    {
        ProgramStatus.EnableGame();

        Round.Generate();
        
    }
}