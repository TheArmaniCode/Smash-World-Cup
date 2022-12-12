using SmashWorldCup.Models;

namespace SmashWorldCup.Interfaces
{
    public interface IStageService
    {
        List<TournamentStageModel> GetStages();
    }
}
