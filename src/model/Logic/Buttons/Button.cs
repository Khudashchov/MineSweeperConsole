using Model.Interfaces;

public class Button : IButton
{
    public virtual void Action()
    {
        Console.Write("Default button action !");
    }
}