using MineSweeper.Model.Pages.Components;

namespace MineSweeper.Model.Abstracts;

public abstract class PageBase<T> where T : ComponentsOfPage
{
    public void Generate(T components)
    {
        Console.Clear();
        components.SetHeader();
        components.SetBody();
    }
}