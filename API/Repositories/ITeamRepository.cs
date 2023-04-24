using API.Models;
using System.Collections.Generic;
using System.Threading;
namespace API.Repositories

{
    public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetTeams();

    Task<Team> GetTeam(int id);

    Task<Team> CreateTeam(Team team);

    Task<bool> UpdateTeam(Team team, int id);

    Task<bool> DeleteTeam(int id);

}
}
