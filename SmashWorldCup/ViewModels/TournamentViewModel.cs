using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;

namespace SmashWorldCup.ViewModels
{
    public class TournamentViewModel : TournamentModel
    {
        ITournamentService _tournamentService;

        public TournamentViewModel()
        {

        }

        public TournamentViewModel(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public TournamentViewModel(int inID, int inGameID, string inName, int inYear)
        {
            ID = inID;
            GameID = inGameID;
            Name = inName;
            Year = inYear;
        }

        public List<MatchViewModel> Matches = new List<MatchViewModel>();
    }
}
