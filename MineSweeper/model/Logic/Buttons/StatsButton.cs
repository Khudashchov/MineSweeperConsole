using MineSweeper.Model.Abstracts;
using MineSweeper.Model.Pages.Components;
using MineSweeper.Model.Pages;

namespace MineSweeper.Model.Logic.Buttons;

public class StatsButton : ButtonBase
{
    PageStats Stats = new PageStats();
    ComponentsOfStatsPage Components = new ComponentsOfStatsPage();

    public override void Action()
    {
        ProgramStatus.DisableMenu();

        Stats.Generate(Components);
        Console.ReadLine();
    }
}