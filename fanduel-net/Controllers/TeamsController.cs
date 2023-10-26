namespace fanduel_net.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fanduel_net.Models;
using fanduel_net.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly ITeamsService _service;

    public TeamsController(ITeamsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Team>>> GetTeams()
    {
        var teams = await _service.GetTeams();
        return Ok(teams);
    }

    [HttpGet("sports/{id}")]
    public async Task<ActionResult<List<Team>>> GetSportsTeam(string id)
    {
        var teams = await _service.GetSportsTeams(id);
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetTeam(string id)
    {
        var team = await _service.GetTeam(id);
        return Ok(team);
    }
}
