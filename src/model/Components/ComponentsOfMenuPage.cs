using Model.Logic.Buttons;

public class ComponentsOfMenuPage : ComponentsOfPage
{
    private MenuLogic _menuLogic = new MenuLogic();
    
    private Dictionary<string, Button> Functions = new Dictionary<string, Button>
    {
        {"PLAY", new PlayButton()},
        {"STATS", new StatsButton()},
        {"EXIT", new ExitButton()}
    };
    protected override void SetBodyComponents()
    {
        _menuLogic.SelectOptionLogic(Functions);
    }
}