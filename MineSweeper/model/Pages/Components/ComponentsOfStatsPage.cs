namespace MineSweeper.Model.Pages.Components;

public class ComponentsOfStatsPage : ComponentsOfPage
{
    protected override void SetBodyComponents()
    {
        Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight / 2);
        Console.Write("This is empty page, but it`s Stats Page !");
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1); 
    }
}