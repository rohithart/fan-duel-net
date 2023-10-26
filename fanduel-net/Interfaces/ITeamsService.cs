namespace fanduel_net.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Models;

public interface ITeamsService
{
    Task<List<Team>> GetTeams();
    Task<List<Team>> GetSportsTeams(string id);
    Task<Team?> GetTeam(string id);
}