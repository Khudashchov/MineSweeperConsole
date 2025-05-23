using MineSweeper.Interfaces;
using MineSweeper.Pages;
using MineSweeper.Status;

namespace MineSweeper.Logic.Menu.Buttons;

public class StatsButton : IButton
{
    private PageStats _stats;

    public StatsButton()
    {
        _stats = new PageStats();
    }
    public void Action()
    {
        _stats.Generate();

        ProgramStatus.EnableMenu();

        Console.ReadLine();
    }
}