namespace fanduel_net.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fanduel_net.Models;
using fanduel_net.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class SportsController : ControllerBase
{
    private readonly ISportsService _service;

    public SportsController(ISportsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sport>>> GetSports()
    {
        var sports = await _service.GetSports();
        return Ok(sports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sport>> GetSport(string id)
    {
        var sport = await _service.GetSport(id);
        return Ok(sport);
    }
}
