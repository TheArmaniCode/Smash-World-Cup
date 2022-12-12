using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.Services
{
    public class MatchService : IMatchService
    {
        private readonly SmashDbContext _smashDbContext;
        public MatchService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public MatchModel GetMatchByID(int inID)
        {
            return _smashDbContext.Matches.Where(m => m.ID == inID).FirstOrDefault();
        }

        public string AddMatch(int inFighter1ID, int inFighter2ID, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inSuddenDeath)
        {
            var match = new MatchModel();

            match.Fighter1 = inFighter1ID;
            match.Fighter2 = inFighter2ID;
            match.Score1 = inScore1;
            match.Score2 = inScore2;
            match.TournamentID = inTournamentID;
            match.StageID = inStageID;
            if(inDate.ToString() != "01/01/0001 00:00:00") match.Date = inDate;
            if(inVenueID != 0) match.VenueID = inVenueID;
            if (inSuddenDeath != 0) match.SuddenDeath = inSuddenDeath;

            _smashDbContext.Matches.Add(match);
            _smashDbContext.SaveChanges();

            return "Match Added!";
        }

        public void EditMatch(int inID, int inFighter1, int inFighter2, int inScore1, int inScore2, int inTournamentID, int inStageID, DateTime inDate, int inVenueID, int inSuddenDeath)
        {
            var match = _smashDbContext.Matches.FirstOrDefault(m => m.ID == inID);

            match.Fighter1 = inFighter1;
            match.Fighter2 = inFighter2;
            match.Score1 = inScore1;
            match.Score2 = inScore2;
            match.TournamentID = inTournamentID;
            match.StageID = inStageID;
            if (inDate.ToString() != "01/01/0001 00:00:00") match.Date = inDate;
            if (inVenueID != 0) match.VenueID = inVenueID;
            if (inSuddenDeath != 0) match.SuddenDeath = inSuddenDeath;

            _smashDbContext.Matches.Update(match);
            _smashDbContext.SaveChanges();
        }
    }
}
