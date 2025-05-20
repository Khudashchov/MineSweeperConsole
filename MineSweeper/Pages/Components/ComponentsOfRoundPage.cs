using MineSweeper.Logic;
using MineSweeper.Abstracts;

namespace MineSweeper.Pages.Components;

public class ComponentsOfRoundPage : ComponentsOfPageBase
{
    protected override void SetBodyComponents()
    {
        DisplayConfig();
        RoundLogic logic = new RoundLogic(10);
        logic.Generate();
    }

    private void DisplayConfig()
    {
        Console.SetCursorPosition(2, Console.WindowHeight / 2);
        Console.WriteLine("Esc - exit the game");
        Console.SetCursorPosition(2, Console.WindowHeight / 2 + 1);
        Console.WriteLine("Arrows - move the cursor");
        Console.SetCursorPosition(2, Console.WindowHeight / 2 + 2);
        Console.WriteLine("Enter - open the cell");
    }
}