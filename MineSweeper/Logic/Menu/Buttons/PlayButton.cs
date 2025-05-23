using MineSweeper.Interfaces;
using MineSweeper.Pages;
using MineSweeper.Status;

namespace MineSweeper.Logic.Menu.Buttons;

public class PlayButton : IButton
{
    private PageRound _round;
    
    public PlayButton()
    {
        _round = new PageRound();
    }

    public void Action()
    {
        ProgramStatus.EnableGame();

        _round.Generate();
        
        ProgramStatus.EnableMenu();
    }
}