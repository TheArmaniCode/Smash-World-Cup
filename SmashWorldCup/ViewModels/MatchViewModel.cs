using SmashWorldCup.Models;

namespace SmashWorldCup.ViewModels
{
    public class MatchViewModel : MatchModel
    {
        public MatchViewModel()
        {

        }

        public MatchViewModel(int inID, int inFighter1, string inFighter1Name, int inFighter2, string inFighter2Name, int inTournamentID, string inTournament, int inVenueID, string inVenue, int inStageID, string inStage, int inRoundID, string inRound, int inSuddenDeath, string inSuddenDeathWinner)
        {
            ID = inID;
            Fighter1 = inFighter1;
            Fighter2 = inFighter2;
            Fighter1Name = inFighter1Name;
            Fighter2Name = inFighter2Name;
            TournamentID = inTournamentID;
            Tournament = inTournament;
            VenueID = inVenueID;
            Venue = inVenue;
            StageID = inStageID;
            Stage = inStage;
            RoundID = inRoundID;
            Round = inRound;
            SuddenDeath = inSuddenDeath;
            SuddenDeathWinner = inSuddenDeathWinner;
        }

        public string Fighter1Name { get; set; }
        public string Fighter2Name { get; set; }
        public string Tournament { get; set; }
        public string Venue { get; set; }
        public string Stage { get; set; }
        public int RoundID { get; set; }
        public string Round { get; set; }
        public string SuddenDeathWinner { get; set; }
    }
}
