using System;
using System.Threading.Tasks;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult> getAll()
        {
            return Ok (await _teamRepository.GetTeams());

        }
        [HttpGet("{id}")]
        public async Task <IActionResult> getTeam(int id)
        {
            return Ok(await _teamRepository.GetTeam(id));
        }
        [HttpPost]
        public async Task<IActionResult> createTeam([FromBody]Team team)
        {
          if (team == null)
            {
                return BadRequest();
            }
            var created = await _teamRepository.CreateTeam(team);
            return Created("Created", created);
        }
    }
}
