using MineSweeper.Logic.Menu.Buttons;
using MineSweeper.Interfaces;
using MineSweeper.Abstracts;
using MineSweeper.Logic;

namespace MineSweeper.Pages.Components;

public class ComponentsOfMenuPage : ComponentsOfPageBase
{
    private Dictionary<string, IButton> _functions = new Dictionary<string, IButton>
    {
        {"PLAY", new PlayButton()},
        {"STATS", new StatsButton()},
        {"EXIT", new ExitButton()}
    };
    protected override void SetBodyComponents()
    {
        IMenuLogic menuLogic = new MenuLogic();
        menuLogic.SelectOption(_functions).Action();
    }
}