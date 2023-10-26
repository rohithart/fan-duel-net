namespace fanduel_net.Service;

using System.Collections.Generic;
using System.Threading.Tasks;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class PlayersService : IPlayersService
{
    private readonly IPlayersRepository _repository;

    public PlayersService(IPlayersRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Player>> GetPlayers()
    {
        return await _repository.GetPlayers();
    }

    public async Task<List<Player>> GetTeamPlayers(string id)
    {
        return await _repository.GetTeamPlayers(id);
    }

    public Player AddPlayer(Player player)
    {
        string playerId = Guid.NewGuid().ToString();
        player.Id = playerId;
        return _repository.AddPlayer(player);
    }

    public Player? GetPlayer(string id)
    {
        return _repository.GetPlayer(id);
    }
}
