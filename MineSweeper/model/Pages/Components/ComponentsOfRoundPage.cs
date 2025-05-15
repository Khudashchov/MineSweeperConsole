using MineSweeper.Model.Logic;

namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfRoundPage : ComponentsOfPage
{
    // private Dictionary<string, (int, int)> _sizeName = new Dictionary<string, (int, int)>()
    // {
    //     {"Small", (11, 22)},
    //     {"Medium", (22, 33)},
    //     {"Large", (33, 48)}
    // };
    protected override void SetBodyComponents()
    {
        RoundLogic logic = new RoundLogic(158);
        logic.Generate();
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1); 
    }

    // private bool SelectSize()
    // {
    //     return true;
    // }

    // private bool SelectComplexity()
    // {
    //     return true;
    // }
}