public class ComponentsOfMainMenuPage : СomponentsOfPage
{
    string[] Functions = {
        "PLAY",
        "STATS",
        "EXIT"
    };
    public override void SetBodyComponents()
    {
        for(int i = 0; i < Functions.Length; i++)
        {
            _cursor.SetCursorCenter((Console.WindowHeight / 2) + (i * 3), Console.WindowWidth - 2, Functions[i]);
            Console.Write(Functions[i]);
        }
    }
}