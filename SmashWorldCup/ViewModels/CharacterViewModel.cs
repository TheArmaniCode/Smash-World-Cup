using SmashWorldCup.Models;

namespace SmashWorldCup.ViewModels
{
    public class CharacterViewModel : CharacterModel
    {
        public CharacterViewModel()
        {

        }

        public CharacterViewModel(int inID, string inName, int? inRank, int inGameID, string inGame, int inWins, string? inLogo, string inColor, string inTextColor)
        {
            ID = inID;
            Name = inName;
            Rank = inRank;
            GameID = inGameID;
            Game = inGame;
            Wins = inWins;
            Logo = inLogo;
            Color = inColor;
            TextColor = inTextColor;
        }
        public string Game { get; set; }

    }
}
