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
        File.SetAttributes(StatsFilePath, FileAttributes.ReadOnly);

        _records = new List<StatsRecord>();
        _records = LoadStats();
        _records = _records.OrderBy(r => r.Seconds).ToList();
    }

    private List<StatsRecord> LoadStats()
    {
        File.SetAttributes(StatsFilePath, FileAttributes.Normal);

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

        File.SetAttributes(StatsFilePath, FileAttributes.ReadOnly);
        return _records;

    }

    public List<StatsRecord> GetAllStats()
    {
        return _records;
    }

    public void SaveRoundStats(StatsRecord newStat)
    {
        File.SetAttributes(StatsFilePath, FileAttributes.Normal);

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

        File.SetAttributes(StatsFilePath, FileAttributes.ReadOnly);

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