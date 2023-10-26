namespace fanduel_net.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Models;

public interface ISportsService
{
    Task<List<Sport>> GetSports();
    Task<Sport?> GetSport(string id);
}
