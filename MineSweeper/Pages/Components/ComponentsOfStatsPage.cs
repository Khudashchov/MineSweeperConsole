using MineSweeper.Abstracts;
using MineSweeper.Logic;
using MineSweeper.Logic.Stats;
using MineSweeper.Interfaces;

namespace MineSweeper.Pages.Components;

public class ComponentsOfStatsPage : ComponentsOfPageBase
{
    protected override void SetBodyComponents()
    {
        IStatsLogic _statsLogic = new StatsLogic();
        ShowStats(_statsLogic);
    }

    private void ShowStats(IStatsLogic _statsLogic, int i = 0)
    {
        List<StatsRecord> stats = _statsLogic.GetAllStats();

        foreach (var stat in stats)
        {
            Cursor.SetCursorCenter(Console.WindowHeight / 2 + i, Console.WindowWidth / 2, "     ");
            Console.WriteLine($"{i + 1} | Time: {ConvertSeconds(stat.Seconds)}, Date: {stat.Date}");
            i++;
        }
    }

    private string ConvertSeconds(int seconds)
    { 
        return $"{seconds / 60:D2}:{seconds % 60:D2}";
    }
}