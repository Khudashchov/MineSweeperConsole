using Model.Interfaces;

public class PageStats : ComponentsOfStatsPage, IPage
{
    public void Generate()
    {
        Console.Clear();
        SetHeader();
        SetBody();
    }
}