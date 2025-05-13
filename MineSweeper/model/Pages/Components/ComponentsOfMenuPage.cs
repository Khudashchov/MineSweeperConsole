using MineSweeper.Model.Logic.Buttons;
using MineSweeper.Model.Abstracts;

namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfMenuPage : ComponentsOfPage
{
    private MenuLogic _menuLogic = new MenuLogic();
    
    private Dictionary<string, ButtonBase> Functions = new Dictionary<string, ButtonBase>
    {
        {"PLAY", new PlayButton()},
        {"STATS", new StatsButton()},
        {"EXIT", new ExitButton()}
    };
    protected override void SetBodyComponents()
    {
        _menuLogic.SelectOption(Functions);
    }
}