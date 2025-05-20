using MineSweeper.Abstracts;
using MineSweeper.Logic;
using MineSweeper.Logic.Stats;

namespace MineSweeper.Pages.Components;

public class ComponentsOfStatsPage : ComponentsOfPageBase
{
    private StatsLogic _statsLogic = new StatsLogic();
    protected override void SetBodyComponents()
    {
        ShowStats();
    }

    private void ShowStats(int i = 0)
    {
        List<StatsRecord> stats = _statsLogic.GetAllStats();

        foreach (var stat in stats)
        {
            Cursor.SetCursorCenter(Console.WindowHeight / 2 + i, Console.WindowWidth / 2, " ");
            Console.WriteLine($"Seconds: {ConvertSeconds(stat.Seconds)}, Date: {stat.Date}");
            i++;
        }
    }

    private string ConvertSeconds(int seconds)
    { 
        return $"{seconds / 60:D2}:{seconds % 60:D2}";
    }
}