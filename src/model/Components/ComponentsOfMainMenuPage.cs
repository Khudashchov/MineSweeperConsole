using Model.Logic.Buttons;

public class ComponentsOfMainMenuPage : СomponentsOfPage
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