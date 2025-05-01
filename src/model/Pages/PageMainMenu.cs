using Model.Interfaces;

public class PageMainMenu : ComponentsOfMenuPage, IPage
{
        public void Generate()
    {
        Console.Clear();
        SetHeader();
        SetBody();
    }
}