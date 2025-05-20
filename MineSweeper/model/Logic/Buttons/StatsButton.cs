using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Pages;

namespace MineSweeper.Model.Logic.Buttons;

public class StatsButton : IButton
{
    PageStats Stats = new PageStats();

    public void Action()
    {
        Stats.Generate();
        Console.ReadLine();
    }
}