namespace fanduel_net.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fanduel_net.Models;
using fanduel_net.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IPlayersService _service;

    public PlayersController(IPlayersService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Player>>> GetPlayers()
    {
        var players = await _service.GetPlayers();
        return Ok(players);
    }

    [HttpGet("team/{id}")]
    public async Task<ActionResult<List<Team>>> GetTeamPlayers(string id)
    {
        var players = await _service.GetTeamPlayers(id);
        return Ok(players);
    }

    [HttpPost]
    public ActionResult<List<Player>> AddPlayer(Player player)
    {
        var newPlayer = _service.AddPlayer(player);
        return Ok(newPlayer);
    }
}
