using SmashWorldCup.Models;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterModel> GetCharacters();
        CharacterModel GetCharacterByID(int inID);
        CharacterViewModel GetCharacterForView(int inID);
        CharacterModel GetCharacterByName(string inName);
        List<TournamentRankingViewModel> GetRankingsByCharacter(int inID);
        List<CharacterModel> SearchCharacters(string inSearchValue, string inSearchCategory);
    }
}
