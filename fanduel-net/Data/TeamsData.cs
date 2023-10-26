namespace fanduel_net.Data;

using System.Collections.Generic;
using fanduel_net.Models;

public static class TeamsData
{
    public static Team ManU { get; } = new Team("1", "Manchester United", SportsData.Soccer);
    public static Team Miami { get; } = new Team("2", "Inter Miami", SportsData.Soccer);
    public static Team NYG { get; } = new Team("3", "NewYork Giants", SportsData.NFL);
    public static Team PhiladelphiaEagles { get; } = new Team("4", "Philadelphia Eagles", SportsData.NFL);
    public static Team TampaBay { get; } = new Team("5", "Tampa Bay", SportsData.NFL);


    private static List<Team> _teams = new List<Team>
    {
        ManU,
        Miami,
        NYG,
        PhiladelphiaEagles,
        TampaBay
    };

    public static IReadOnlyList<Team> AllTeams => _teams.AsReadOnly();

    public static void AddTeam(Team team)
    {
        _teams.Add(team);
    }
}
