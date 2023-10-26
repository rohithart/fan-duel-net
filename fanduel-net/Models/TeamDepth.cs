using fanduel_net.Models;

public class TeamDepth
{
    public string Id { get; set; }
    public Team Team { get; set; }
    public Dictionary<string, List<Player>> DepthChart { get; set; }

    public TeamDepth(string id, Team team)
    {
        Id = id;
        Team = team;
        DepthChart = new Dictionary<string, List<Player>>();
    }

    public Player AddPlayerToDepthChart(string position, Player player, int? positionDepth = null)
    {
        if (!DepthChart.ContainsKey(position))
        {
            DepthChart[position] = new List<Player> { player };
        }
        else
        {
            var players = RemovePlayerIfAlreadyExists(position, player);

            if (!positionDepth.HasValue || positionDepth < 1 || positionDepth > players.Count)
            {
                players.Add(player);
            }
            else
            {
                players.Insert(positionDepth.Value - 1, player);
            }
        }
        return player;
    }

    public Player? RemovePlayerFromDepthChart(string position, Player player)
    {
        if (DepthChart.ContainsKey(position))
        {
            var positionDepthChart = DepthChart[position];
            var playerIndex = positionDepthChart.FindIndex(node => node == player);

            if (playerIndex >= 0)
            {
                var removedPlayer = positionDepthChart[playerIndex];
                positionDepthChart.RemoveAt(playerIndex);
                return removedPlayer;
            }
        }

        return null;
    }

    public List<Player> GetBackups(string position, Player player)
    {
        if (DepthChart.ContainsKey(position))
        {
            var positionDepthChart = DepthChart[position];
            var playerIndex = positionDepthChart.FindIndex(node => node == player);

            if (playerIndex >= 0)
            {
                return positionDepthChart.GetRange(playerIndex + 1, positionDepthChart.Count - playerIndex - 1);
            }
        }

        return new List<Player>();
    }

    private List<Player> RemovePlayerIfAlreadyExists(string position, Player player)
    {
        var players = DepthChart[position];
        var playerIndex = players.FindIndex(p => p.Id == player.Id);

        if (playerIndex != -1)
        {
            players.RemoveAt(playerIndex);
        }

        return players;
    }
}
