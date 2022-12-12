using SmashWorldCup.Models;

namespace SmashWorldCup.Interfaces
{
    public interface IMatchService
    {
        MatchModel GetMatchByID(int inID);
        void EditMatch(int inID, int inFighter1, int inFighter2, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inSuddenDeath);
        string AddMatch(int inFighter1ID, int inFighter2ID, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inSuddenDeath);
    }
}
