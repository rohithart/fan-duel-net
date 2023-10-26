namespace fanduel_net.Service;

using fanduel_net.Interfaces;
using fanduel_net.Models;

public class TeamDepthService : ITeamDepthService
{
    private readonly IPlayersService _playerservice;
    private readonly ITeamDepthRepository _repository;

    public TeamDepthService(ITeamDepthRepository repository, IPlayersService playersService)
    {
        _repository = repository;
        _playerservice = playersService;
    }

    public async Task<TeamDepth> GetTeamDepth(string id)
    {
        TeamDepth? teamDepth = await _repository.GetTeamDepth(id);
        return teamDepth;
    }

    public async Task<Player> AddPlayer(string id, string? position, string? playerId, int? positionDepth)
    {
        if (playerId == null || position == null)
            throw new ArgumentNullException("Invalid request");

        Player? player = _playerservice.GetPlayer(playerId);
        if (player == null)
            throw new ArgumentNullException("Player not found");


        return await _repository.AddPlayer(id, position, player, positionDepth);
    }

    public async Task<Player> RemovePlayer(string id, string position, string playerId)
    {
        if (playerId == null || position == null)
            throw new ArgumentNullException("Invalid request");

        Player? player = _playerservice.GetPlayer(playerId);
        if (player == null)
            throw new ArgumentNullException("Player not found");

        return await _repository.RemovePlayer(id, position, player);
    }


    public async Task<List<Player>> GetBackupPlayers(string id, string? position, string? playerId, int depth)
    {
        if (playerId == null || position == null)
            throw new ArgumentNullException("Invalid request");

        Player? player = _playerservice.GetPlayer(playerId);
        if (player == null)
            throw new ArgumentNullException("Player not found");

        return await _repository.GetBackupPlayers(id, position, player);
    }
}
