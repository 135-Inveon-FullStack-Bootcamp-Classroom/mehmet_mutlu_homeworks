﻿using FootballManagerApi.Data;
using FootballManagerApi.ServiceAbstracts;
using System.Threading.Tasks;

namespace FootballManagerApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ITeamService teamService, IFootballerService footballerService, ICoachService coachService, ApplicationDbContext dbContext, ITacticService tacticService, IManagementPositionService managementPositionService, IManagerService managerService, INationalTeamService nationalTeamService, IPositionService positionService)
        {
            _dbContext = dbContext;
            this.FootballerService = footballerService;
            this.TacticService = tacticService;
            this.CoachService = coachService;
            this.ManagementPositionService = managementPositionService;
            this.TeamService = teamService;
            this.PositionService = positionService;
            this.ManagerService = managerService;
            this.NationalTeamService = nationalTeamService;
        }

        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        public IManagementPositionService ManagementPositionService { get; set; }
        public ICoachService CoachService { get; set; }
        public ITacticService TacticService { get; set; }
        public INationalTeamService NationalTeamService { get; set; }
        public IManagerService ManagerService { get; set; }
        public IPositionService PositionService { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
