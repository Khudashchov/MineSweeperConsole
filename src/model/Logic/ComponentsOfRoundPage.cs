public class ComponentOfRoundPage : СomponentsOfPage
{
    public override void SetBodyComponents()
    {
        Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight / 2);
        Console.Write("This is empty page, but it`s menu !");
        Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 1); 
    }
}