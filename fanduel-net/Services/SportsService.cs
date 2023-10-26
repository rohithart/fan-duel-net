namespace fanduel_net.Service;

using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class SportsService : ISportsService
{
    private readonly ISportsRepository _repository;

    public SportsService(ISportsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Sport>> GetSports()
    {
        return await _repository.GetSports();
    }

    public async Task<Sport?> GetSport(string id)
    {
        return await _repository.GetSport(id);
    }
}
