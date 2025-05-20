using MineSweeper.Logic.Stats;

namespace MineSweeper.Interfaces;

interface IStatsLogic
{
    void SaveRoundStats(StatsRecord stats);
    List<StatsRecord> GetAllStats();
}