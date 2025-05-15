using MineSweeper.Model.Interfaces;
using MineSweeper.Model.Pages.Components;
using MineSweeper.Model.Pages;

namespace MineSweeper.Model.Logic.Buttons;

public class StatsButton : IButton
{
    PageStats Stats = new PageStats();
    ComponentsOfStatsPage Components = new ComponentsOfStatsPage();

    public void Action()
    {
        Stats.Generate(Components);
        Console.ReadLine();
    }
}