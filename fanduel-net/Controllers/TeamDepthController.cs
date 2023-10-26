namespace fanduel_net.Controllers;

using Microsoft.AspNetCore.Mvc;
using fanduel_net.Interfaces;
using fanduel_net.Models;
using fanduel_net.Models.DTO;

[Route("api/[controller]")]
[ApiController]
public class TeamDepthController : ControllerBase
{
    private readonly ITeamDepthService _service;

    public TeamDepthController(ITeamDepthService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDepth>> GetTeamDepth(string id)
    {
        var teamDepth = await _service.GetTeamDepth(id);

        if (teamDepth == null)
            return NotFound();

        return Ok(teamDepth);
    }

    [HttpPost("{id}/add-player")]
    public async Task<ActionResult<Player>> AddPlayer(string id, [FromBody] DepthDTO dto)
    {
        if (dto == null)
            return BadRequest("Invalid data");

        try
        {
            var addedPlayer = await _service.AddPlayer(id, dto.Position, dto.PlayerID, dto.Depth);
            return Ok(addedPlayer);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/remove-player")]
    public async Task<ActionResult<Player>> RemovePlayer(string id, [FromBody] DepthDTO dto)
    {
        if (dto == null)
            return BadRequest("Invalid data");

        var removedPlayer = await _service.RemovePlayer(id, dto.Position, dto.PlayerID);

        if (removedPlayer == null)
            return NotFound();

        return Ok(removedPlayer);
    }

    [HttpPost("{id}/backups")]
    public async Task<ActionResult<List<Player>>> GetBackupPlayers(string id, [FromBody] DepthDTO dto)
    {
        if (dto == null)
            return BadRequest("Invalid data");

        var backupPlayers = await _service.GetBackupPlayers(id, dto.Position, dto.PlayerID, dto.Depth);

        return Ok(backupPlayers);
    }
}
