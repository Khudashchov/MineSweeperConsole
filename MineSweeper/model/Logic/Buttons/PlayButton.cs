using MineSweeper.Model.Abstracts;
using MineSweeper.Model.Pages.Components;
using MineSweeper.Model.Pages;

namespace MineSweeper.Model.Logic.Buttons;

public class PlayButton : ButtonBase
{
    PageRound Round = new PageRound();
    ComponentsOfRoundPage Components = new ComponentsOfRoundPage();
    public override void Action()
    {
        ProgramStatus.DisableMenu();
        ProgramStatus.EnableGame();

        Round.Generate(Components);
        
    }
}