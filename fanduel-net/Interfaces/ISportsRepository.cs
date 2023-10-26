namespace fanduel_net.Interfaces;

using System.Collections.Generic;
using fanduel_net.Models;

public interface ISportsRepository
{
    Task<List<Sport>> GetSports();
    Task<Sport?> GetSport(string id);
}
