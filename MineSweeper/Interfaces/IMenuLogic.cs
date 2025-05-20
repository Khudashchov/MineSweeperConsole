namespace MineSweeper.Interfaces;

public interface IMenuLogic
{
    IButton SelectOption(Dictionary<string, IButton> functions);
}