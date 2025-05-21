using MineSweeper.Interfaces;
using MineSweeper.Logic.Stats;
using System.Text.Json;

namespace MineSweeper.Logic;

public class StatsLogic : IStatsLogic
{
    private const string StatsFilePath = "MineSweeper\\LocalStats\\stats.json";
    private List<StatsRecord> _records;
    private bool _hasChanges = false;

    public StatsLogic()
    {
        _records = new List<StatsRecord>();
        _records = LoadStats();
    }

    private List<StatsRecord> LoadStats()
    {
        if (File.Exists(StatsFilePath))
        {
            var lines = File.ReadAllLines(StatsFilePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var record = JsonSerializer.Deserialize<StatsRecord>(line);
                    _records.Add(record);
                }
            }
        }

        return _records;
    }

    public List<StatsRecord> GetAllStats()
    {
        return _records;
    }

    public void SaveRoundStats(StatsRecord newStat)
    {
        _records.Add(newStat);
        _hasChanges = true;

        _records = _records.OrderBy(r => r.Seconds).ToList();

        if (_records.Count > 5)
        {
            _records = _records.Take(5).ToList();
        }

        if (_hasChanges)
        {
            SaveAllStats(_records);
            _hasChanges = false;
        }
    }

    private void SaveAllStats(List<StatsRecord> records)
    {
        File.WriteAllText(StatsFilePath, string.Empty); 

        foreach (var record in records)
        {
            string json = JsonSerializer.Serialize(record);
            File.AppendAllText(StatsFilePath, json + Environment.NewLine);
        }
    }
}