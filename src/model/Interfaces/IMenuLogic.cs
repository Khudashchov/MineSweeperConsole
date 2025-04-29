using Model.Logic.Buttons;
namespace Model.Interfaces;

public interface IMenuLogic
{
    void SelectOptionLogic(Dictionary<string, Button> Functions);
}