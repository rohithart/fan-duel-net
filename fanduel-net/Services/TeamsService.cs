namespace fanduel_net.Service;

using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class TeamsService : ITeamsService
{
    private readonly ITeamsRepository _repository;

    public TeamsService(ITeamsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Team>> GetTeams()
    {
        return await _repository.GetTeams();
    }

    public async Task<List<Team>> GetSportsTeams(string id)
    {
        return await _repository.GetSportsTeams(id);
    }

    public async Task<Team?> GetTeam(string id)
    {
        return await _repository.GetTeam(id);
    }
}
