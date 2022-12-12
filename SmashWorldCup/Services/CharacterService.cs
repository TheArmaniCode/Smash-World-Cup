using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly SmashDbContext _smashDbContext;
        public CharacterService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public List<CharacterModel> GetCharacters()
        {
            return _smashDbContext.Characters.ToList();
        }

        public CharacterModel GetCharacterByID(int inID)
        {
            return _smashDbContext.Characters.SingleOrDefault(c => c.ID == inID);
        }

        public CharacterViewModel GetCharacterForView(int inID)
        {
            var query = from c in _smashDbContext.Characters
                            join g in _smashDbContext.Games on c.GameID equals g.ID
                            where c.ID == inID
                            select new CharacterViewModel
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Rank = c.Rank,
                                GameID = g.ID,
                                Game = g.Name,
                                Wins = c.Wins,
                                Logo = c.Logo
                            };

            var character = query.FirstOrDefault();

            return character;
        }

        public CharacterModel GetCharacterByName(string inName)
        {
            return _smashDbContext.Characters.SingleOrDefault(c => c.Name == inName);
        }

        public List<TournamentRankingViewModel> GetRankingsByCharacter(int inID)
        {
            var query = from r in _smashDbContext.TournamentRankings
                        join c in _smashDbContext.Characters on r.CharacterID equals c.ID
                        join p in _smashDbContext.Positions on r.PositionID equals p.ID
                        join t in _smashDbContext.Tournaments on r.TournamentID equals t.ID
                        where r.CharacterID == inID
                        select new TournamentRankingViewModel
                        {
                            ID = r.ID,
                            CharacterID = c.ID,
                            Character = c.Name,
                            PositionID = p.ID,
                            Position = p.Name,
                            Rank = r.Rank,
                            TournamentID = t.ID,
                            Tournament = t.Name,
                            Host = r.Host
                        };

            var rankings = query.ToList();

            return rankings;
        }

        public List<CharacterModel> SearchCharacters(string inSearchValue, string inSearchCategory)
        {
            List<CharacterModel> characters = new List<CharacterModel>();

            if (inSearchCategory == "Name")
            {
                characters = _smashDbContext.Characters.Where(c => c.Name == inSearchValue).ToList();
            }

            else if(inSearchCategory == "ID")
            {
                characters = _smashDbContext.Characters.Where(c => c.ID == Int32.Parse(inSearchValue)).ToList();
            }

            else if(inSearchCategory == "Game")
            {
                var game = _smashDbContext.Games.SingleOrDefault(g => g.Name == inSearchValue);
                characters = _smashDbContext.Characters.Where(c => c.GameID == game.ID).ToList();
            }

            return characters;
        }
    }
}
