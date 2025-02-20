using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStatsAPIClient.Responses
{
    public class StandingsResponse // Helper object for holding league results
    {
        public LeagueStanding[] Table { get; set; }
    }
}
