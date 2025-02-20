using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportsStatsAPIClient
{
    public interface ISportsAPIService
    {
        Task<Team> SearchTeam(string teamName);
        Task<LeagueStanding[]> GetLeagueStandings(string leagueId, string season);
        Task<Event[]> GetUpcomingEvents(int teamId);
        Task<Player[]> GetTeamPlayers(int teamId);
        //Task<Event[]> GetLiveScores(); // This is a Premium, V2 API feature...
    }
}
