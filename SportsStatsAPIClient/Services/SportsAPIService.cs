using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SportsStatsAPIClient.Responses;

namespace SportsStatsAPIClient
{
    public class SportsAPIService : ISportsAPIService
    {

        private readonly HttpClient httpClient;
        private const string BaseUrl = "https://www.thesportsdb.com/api/v1/json/3/"; // Use API Key 3 for dev
        public SportsAPIService()
        {
            httpClient = new HttpClient();
        }

        /*
         * Searches TheSportsDB for a valid team by name. Doesn't need to be exact!
         * For example, typing "Cubs" will return data for the Chicago Cubs.
         * Returns null if no teams are found.
        */
        public async Task<Team> SearchTeam(string teamName)
        {
            string url = $"{BaseUrl}searchteams.php?t={teamName}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Parse Json asynchronously
                var json = await response.Content.ReadAsStringAsync();

                // Convert Json to an object using Newtonsoft.Json library
                return JsonConvert.DeserializeObject<TeamResponse>(json)?.Teams?[0];
            }

            return null; // No team found, return null
        }

        /*
         * Searches TheSportsDB for team standings for a valid TeamID
         * Returns null if team is invalid or no data exists.
        */
        public async Task<LeagueStanding[]> GetLeagueStandings(string leagueId, string season)
        {
            string url = $"{BaseUrl}lookuptable.php?l={leagueId}&s={season}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Parse Json asynchronously
                var json = await response.Content.ReadAsStringAsync();

                // Convert Json to an object using Newtonsoft.Json library
                return JsonConvert.DeserializeObject<StandingsResponse>(json)?.Table;
            }

            return null; // No standing found, return null
        }

        /*
         * Searches TheSportsDB for all upcoming events for a valid TeamID
         * Returns null if no events are found, or team is invalid.
        */
        public async Task<Event[]> GetUpcomingEvents(int teamId)
        {
            string url = $"{BaseUrl}eventsnext.php?id={teamId}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Parse Json asynchronously
                var json = await response.Content.ReadAsStringAsync();

                // Convert Json to an object using Newtonsoft.Json library
                return JsonConvert.DeserializeObject<EventResponse>(json)?.Events;
            }

            return null; // No events found, return null
        }

        /*
         * Searches TheSportsDB for a relevant team by valid TeamID
         * Returns null if no teams are found.
        */
        public async Task<Player[]> GetTeamPlayers(int teamId)
        {
            string url = $"{BaseUrl}lookup_all_players.php?id={teamId}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Parse Json asynchronously
                var json = await response.Content.ReadAsStringAsync();

                // Convert Json to an object using Newtonsoft.Json library
                return JsonConvert.DeserializeObject<PlayerResponse>(json)?.Player;
            }

            return null; // No players found, return null
        }

    }
}
