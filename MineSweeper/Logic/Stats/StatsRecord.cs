namespace MineSweeper.Logic.Stats;

public struct StatsRecord
{
    public StatsRecord(int seconds)
    {
        Seconds = seconds;
        Date = DateTime.Now;
    }
    public int Seconds { get; set; }
    public DateTime Date { get; set; }
}