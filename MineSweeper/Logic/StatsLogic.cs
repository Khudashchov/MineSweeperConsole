using MineSweeper.Interfaces;
using MineSweeper.Logic.Stats;
using System.Text.Json;

namespace MineSweeper.Logic;

public class StatsLogic : IStatsLogic
{
    private const string StatsFilePath = "MineSweeper\\LocalStats\\stats.json";
    public StatsLogic()
    {

    }
    public List<StatsRecord> GetAllStats()
    {
        var records = new List<StatsRecord>();

        if (File.Exists(StatsFilePath))
        {
            var lines = File.ReadAllLines(StatsFilePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var record = JsonSerializer.Deserialize<StatsRecord>(line);

                    records.Add(record);
                }
            }
        }

        return records;

    }

    public void SaveRoundStats(StatsRecord stats)
    {
        string json = JsonSerializer.Serialize(stats);
        File.AppendAllText(StatsFilePath, json + Environment.NewLine);
    }
}