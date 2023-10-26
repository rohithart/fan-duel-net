using fanduel_net.Models;

namespace fanduel_net.Interfaces
{
	public interface ITeamDepthRepository
	{
        Task<TeamDepth?> GetTeamDepth(string id);
        Task<Player> AddPlayer(string teamDepth, string position, Player player, int? positionDepth = null);
        Task<Player> RemovePlayer(string teamDepth, string position, Player player);
        Task<List<Player>> GetBackupPlayers(string teamDepth, string position, Player player);
    }
}

