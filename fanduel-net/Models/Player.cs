using System;

namespace fanduel_net.Models;

public class Player
{
    public string Id { get; set; }
    public int Num { get; set; }
    public string Name { get; set; }
    public Team Team { get; set; }

    public Player(string id, int num, string name, Team team)
    {
        Id = id;
        Num = num;
        Name = name;
        Team = team;
    }
}
