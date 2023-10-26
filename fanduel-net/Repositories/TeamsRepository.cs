namespace fanduel_net.Repository;

using System.Collections.Generic;
using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class TeamsRepository : ITeamsRepository
{
    public async Task<List<Team>> GetTeams()
    {
        List<Team> teams = TeamsData.AllTeams.ToList();
        return await Task.FromResult(teams);
    }

    public async Task<List<Team>> GetSportsTeams(string id)
    {
        List<Team> teams = TeamsData.AllTeams.Where((team) => team.Sport.Id == id).ToList();
        return await Task.FromResult(teams);
    }

    public async Task<Team?> GetTeam(string id)
    {
        Team? team = TeamsData.AllTeams.FirstOrDefault((team) => team.Id == id);
        return await Task.FromResult(team);
    }
}