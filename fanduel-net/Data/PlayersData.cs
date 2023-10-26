namespace fanduel_net.Data;

using System.Collections.Generic;
using fanduel_net.Models;

public static class PlayerData
{
    private static List<Player> _players = new List<Player>();

    public static IReadOnlyList<Player> AllPlayers => _players.AsReadOnly();

    public static void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    static PlayerData()
    {
        _players.AddRange(new List<Player>
        {
            new Player("1", 10, "Lionel Messi", TeamsData.Miami),
            new Player("2", 2, "DeAndre Yedlin", TeamsData.Miami),
            new Player("3", 12, "Tom Brady", TeamsData.TampaBay),
            new Player("4", 11, "Blaine Gabbert", TeamsData.TampaBay),
            new Player("5", 2, "Kyle Trask", TeamsData.TampaBay),
            new Player("6", 13, "Mike Evans", TeamsData.TampaBay),
            new Player("7", 1, "Jaelon Darden", TeamsData.TampaBay),
            new Player("8", 10, "Scott Miller", TeamsData.TampaBay),
        });
    }
}
