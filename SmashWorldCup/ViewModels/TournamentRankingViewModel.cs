using SmashWorldCup.Models;

namespace SmashWorldCup.ViewModels
{
    public class TournamentRankingViewModel : TournamentRankingModel
    {
        public TournamentRankingViewModel()
        {

        }

        public TournamentRankingViewModel(int inID, int inCharacterID, string inCharacter, int inPositionID, string inPosition, string inRank, int inTournamentID, string inTournament, bool inHost)
        {
            ID = inID;
            CharacterID = inCharacterID;
            Character = inCharacter;
            PositionID = inPositionID;
            Position = inPosition;
            Rank = inRank;
            TournamentID = inTournamentID;
            Tournament = inTournament;
            Host = inHost;
        }
        public string Character { get; set; }
        public string Position { get; set; }
        public string Tournament { get; set; }
    }
}
