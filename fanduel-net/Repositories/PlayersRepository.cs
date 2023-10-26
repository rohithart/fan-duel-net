namespace fanduel_net.Repository;

using System.Collections.Generic;
using fanduel_net.Data;
using fanduel_net.Interfaces;
using fanduel_net.Models;

public class PlayersRepository : IPlayersRepository
{
    public async Task<List<Player>> GetPlayers()
    {
        List<Player> players = PlayerData.AllPlayers.ToList();
        return await Task.FromResult(players);
    }

    public async Task<List<Player>> GetTeamPlayers(string id)
    {
        List<Player> players = PlayerData.AllPlayers.Where((player) => player.Team.Id == id).ToList();
        return await Task.FromResult(players);
    }

    public Player AddPlayer(Player player)
    {
        PlayerData.AddPlayer(player);
        return player;
    }

    public Player? GetPlayer(string id)
    {
        Player? player = PlayerData.AllPlayers.FirstOrDefault((player) => player.Id == id);
        return player;
    }
}
