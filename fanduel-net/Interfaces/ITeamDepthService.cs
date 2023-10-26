using fanduel_net.Models;

namespace fanduel_net.Interfaces
{
	public interface ITeamDepthService
	{
        Task<TeamDepth> GetTeamDepth(string id);
        Task<Player> AddPlayer(string id, string? position, string? player, int? positionDepth = null);
        Task<Player> RemovePlayer(string id, string? position, string? player);
        Task<List<Player>> GetBackupPlayers(string id, string? position, string? player, int depth);
    }
}
