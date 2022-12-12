using SmashWorldCup.Models;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Interfaces
{
    public interface ITournamentService
    {
        List<TournamentModel> GetTournaments();
        TournamentViewModel GetMostRecentTournament();
        TournamentViewModel GetTournamentByID(int inTournamentID);
        List<MatchViewModel> GetMatchesByTournament(int inTournamentID);
        List<CharacterModel> GetTopFourCharacters(int inTournamentID);
        List<MatchViewModel> GetMatchesByStage(int inTournamentID, int inStageID);
        List<TournamentTableViewModel> CalculateTable(int inTournamentID, int inStageID);
        TournamentTableViewModel CalculateResult(TournamentTableViewModel inCharacter, int inScore1, int inScore2);
        string GetCharacterFinish(int inCharacterID, int inTournamentID);
        string AddOrdinal(int num);
    }
}
