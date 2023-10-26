namespace fanduel_net.Repository;

using System.Collections.Generic;
using System.Linq;
using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class SportsRepository : ISportsRepository
{
    public async Task<List<Sport>> GetSports()
    {
        List<Sport> sports = SportsData.AllSports.ToList();
        return await Task.FromResult(sports);
    }

    public async Task<Sport?> GetSport(string id)
    {
        Sport? sport = SportsData.AllSports.FirstOrDefault((sport) => sport.Id == id);
        return await Task.FromResult(sport);
    }
}
