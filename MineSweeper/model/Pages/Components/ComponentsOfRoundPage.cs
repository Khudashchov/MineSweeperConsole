using MineSweeper.Model.Logic;
using MineSweeper.Model.Abstracts;

namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfRoundPage : ComponentsOfPageBase
{
    protected override void SetBodyComponents()
    {
        RoundLogic logic = new RoundLogic(158);
        logic.Generate();
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1); 
    }
}