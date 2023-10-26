namespace fanduel_net.Data;

using System.Collections.Generic;

public static class DepthData
{
    public static List<TeamDepth> _depthData = new List<TeamDepth>();


    public static IReadOnlyList<TeamDepth> AllDepths => _depthData.AsReadOnly();

    public static void AddDepth(TeamDepth depth)
    {
        _depthData.Add(depth);
    }

    public static void UpdateDepth(TeamDepth newDepth)
    {
        var existingDepth = _depthData.Find(d => d.Id == newDepth.Id);

        if (existingDepth != null)
        {
            existingDepth.DepthChart = newDepth.DepthChart;
        }
    }

    static DepthData()
    {
        _depthData.AddRange(new List<TeamDepth>
        {
            new TeamDepth("1", TeamsData.Miami),
            new TeamDepth("2", TeamsData.TampaBay),
        });
    }
}
