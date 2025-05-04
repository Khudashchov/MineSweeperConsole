using MineSweeper.Model.Abstracts;

namespace MineSweeper.Model.Interfaces;

public interface IMenuLogic
{
    void SelectOption(Dictionary<string, ButtonBase> Functions);
}