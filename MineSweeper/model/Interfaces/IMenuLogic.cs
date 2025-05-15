namespace MineSweeper.Model.Interfaces;

public interface IMenuLogic
{
    IButton SelectOption(Dictionary<string, IButton> Functions);
}