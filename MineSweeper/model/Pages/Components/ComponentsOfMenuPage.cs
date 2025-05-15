using MineSweeper.Model.Logic.Buttons;
using MineSweeper.Model.Interfaces;

namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfMenuPage : ComponentsOfPage
{
    private MenuLogic _menuLogic = new MenuLogic();
    
    private Dictionary<string, IButton> Functions = new Dictionary<string, IButton>
    {
        {"PLAY", new PlayButton()},
        {"STATS", new StatsButton()},
        {"EXIT", new ExitButton()}
    };
    protected override void SetBodyComponents()
    {
        _menuLogic.SelectOption(Functions).Action();
    }
}