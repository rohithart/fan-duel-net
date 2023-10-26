namespace fanduel_net.Repository;

using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class TeamDepthRepository : ITeamDepthRepository
{
    public Task<TeamDepth?> GetTeamDepth(string id)
    {
        TeamDepth? teamDepth = DepthData.AllDepths.FirstOrDefault(td => td.Team.Id == id);
        return Task.FromResult(teamDepth);
    }

    public async Task<Player> AddPlayer(string id, string position, Player player, int? positionDepth = null)
    {
        TeamDepth? teamDepth = await GetTeamDepth(id);
        teamDepth.AddPlayerToDepthChart(position, player, positionDepth);
        DepthData.UpdateDepth(teamDepth);

        return await Task.FromResult(player);
    }

    public async Task<Player> RemovePlayer(string id, string position, Player player)
    {
        TeamDepth? teamDepth = await GetTeamDepth(id);
        Player? removedPlayer = teamDepth.RemovePlayerFromDepthChart(position, player);
        DepthData.UpdateDepth(teamDepth);
        return await Task.FromResult(removedPlayer);
    }

    public async Task<List<Player>> GetBackupPlayers(string id, string position, Player player)
    {
        TeamDepth? teamDepth = await GetTeamDepth(id);
        return await Task.FromResult(teamDepth.GetBackups(position, player));
    }
}
