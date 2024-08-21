using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Dashboard.Services
{
    public interface IDataService
    {
        IEnumerable<PlayerStats> GetPlayerStats(string csvFilePath);
    }

}
