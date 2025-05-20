namespace MineSweeper.Model.Abstracts;

public abstract class PageBase<T> where T : ComponentsOfPageBase, new()
{
    protected T components;
    public PageBase()
    {
        components = new T();
    }
    public void Generate()
    {
        Console.Clear();
        components.SetHeader();
        components.SetBody();
    }   
}