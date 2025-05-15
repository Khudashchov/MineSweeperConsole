using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Pages.Components;
using MineSweeper.Model.Pages;

namespace MineSweeper.Model.Logic.Buttons;

public class PlayButton : IButton
{
    PageRound Round = new PageRound();
    ComponentsOfRoundPage Components = new ComponentsOfRoundPage();
    public void Action()
    {
        ProgramStatus.EnableGame();

        Round.Generate(Components);
        
    }
}