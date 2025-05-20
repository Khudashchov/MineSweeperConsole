using MineSweeper.Interfaces;
using MineSweeper.Pages;

namespace MineSweeper.Logic.Buttons;

public class StatsButton : IButton
{
    PageStats Stats = new PageStats();

    public void Action()
    {
        Stats.Generate();
        Console.ReadLine();
    }
}