using FootballManagerApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceAbstracts
{
    public interface ITeamService : IBaseService<Team>
    {
        public Task<IEnumerable<Team>> GetAllWithFootballersAsync();
    }
}
