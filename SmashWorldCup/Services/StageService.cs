using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.Services
{
    public class StageService : IStageService
    {
        private readonly SmashDbContext _smashDbContext;

        public StageService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public List<TournamentStageModel> GetStages()
        {
            return _smashDbContext.TournamentStages.ToList();
        }
    }
}
