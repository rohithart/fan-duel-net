namespace fanduel_net.Interfaces;

using System.Collections.Generic;
using fanduel_net.Models;

public interface ITeamsRepository
{
    Task<List<Team>> GetTeams();
    Task<List<Team>> GetSportsTeams(string id);
    Task<Team?> GetTeam(string id);
}