using FootballManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceAbstracts
{
    public interface INationalTeamService : IBaseService<NationalTeam>
    {
        public Task<IEnumerable<Team>> GetAllWithFootballersAsync();
    }
}
