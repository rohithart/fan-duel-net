using System;

namespace fanduel_net.Models;

public class Team
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Sport Sport { get; set; }

    public Team(string id, string name, Sport sport)
    {
        Id = id;
        Name = name;
        Sport = sport;
    }
}
