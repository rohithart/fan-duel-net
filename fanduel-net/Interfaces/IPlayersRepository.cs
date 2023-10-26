namespace fanduel_net.Interfaces;

using System.Collections.Generic;
using fanduel_net.Models;

public interface IPlayersRepository
{
    Task<List<Player>> GetPlayers();
    Task<List<Player>> GetTeamPlayers(string id);
    Player AddPlayer(Player player);
    Player? GetPlayer(string id);
}
