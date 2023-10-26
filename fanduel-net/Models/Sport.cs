namespace fanduel_net.Models;

public class Sport
{
    public string Id { get; set; }
    public string Name { get; set; }

    public Sport(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
