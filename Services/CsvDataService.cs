using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WPF_MVVM_Dashboard.Services
{
    public class CsvDataService : IDataService
    {
        public IEnumerable<PlayerStats> GetPlayerStats(string csvFilePath)
        {
            var lines = File.ReadAllLines(csvFilePath).Skip(1); // Skip the header row

            return lines.Select(line =>
            {
                var parts = line.Split(',');
                return new PlayerStats
                {
                    PlayerName = parts[0],
                    GamesPlayed = int.Parse(parts[1]),
                    AverageScore = double.Parse(parts[2])
                };
            }).ToList();
        }
    }
}
