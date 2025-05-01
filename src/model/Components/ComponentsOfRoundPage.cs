public class ComponentsOfRoundPage : ComponentsOfPage
{
    protected override void SetBodyComponents()
    {
        RoundLogic logic = new RoundLogic();
        logic.Generate();
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1); 
    }
}