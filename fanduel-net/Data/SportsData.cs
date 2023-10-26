namespace fanduel_net.Data;

using System.Collections.Generic;
using fanduel_net.Models;

public static class SportsData
{
    public static Sport Soccer { get; } = new Sport("1", "Soccer");
    public static Sport NFL { get; } = new Sport("2", "NFL");

    private static List<Sport> _sports = new List<Sport>
    {
        Soccer,
        NFL,
    };

    public static IReadOnlyList<Sport> AllSports => _sports.AsReadOnly();

    public static void AddSport(Sport sport)
    {
        _sports.Add(sport);
    }
}
