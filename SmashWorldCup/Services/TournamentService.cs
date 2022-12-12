using SmashWorldCup.Data;
using SmashWorldCup.Interfaces;
using SmashWorldCup.Models;
using SmashWorldCup.ViewModels;

namespace SmashWorldCup.Services
{
    public class TournamentService : ITournamentService
    {
        public SmashDbContext _smashDbContext;
        public TournamentService(SmashDbContext smashDbContext)
        {
            _smashDbContext = smashDbContext;
        }

        public List<TournamentModel> GetTournaments()
        {
            return _smashDbContext.Tournaments.ToList();
        }

        public TournamentViewModel GetTournamentByID(int inTournamentID)
        {
            var query = from t in _smashDbContext.Tournaments
                        join g in _smashDbContext.Games on t.GameID equals g.ID
                        where t.ID == inTournamentID
                        select new TournamentViewModel()
                        {
                            ID = t.ID,
                            GameID = g.ID,
                            Name = t.Name
                        };

            var tournament = query.FirstOrDefault();
            tournament.Matches = GetMatchesByTournament(tournament.ID);

            return (tournament);
        }

        public TournamentViewModel GetMostRecentTournament()
        {
            var query = from t in _smashDbContext.Tournaments
                        join g in _smashDbContext.Games on t.GameID equals g.ID
                        orderby t.ID descending
                        select new TournamentViewModel()
                        {
                            ID = t.ID,
                            GameID = g.ID,
                            Name = t.Name
                        };

            var tournament = query.First();
            tournament.Matches = GetMatchesByTournament(tournament.ID);

            return (tournament);
        }

        public List<MatchViewModel> GetMatchesByTournament(int inTournamentID)
        {
            var query = from m in _smashDbContext.Matches
                        join t in _smashDbContext.Tournaments on m.TournamentID equals t.ID
                        join s in _smashDbContext.TournamentStages on m.StageID equals s.ID
                        join r in _smashDbContext.TournamentRounds on s.RoundID equals r.ID
                        join v in _smashDbContext.Venues on new { Venue = m.VenueID } equals new { Venue = (int?)v.ID } into mv
                        from vn in mv.DefaultIfEmpty()
                        where t.ID == inTournamentID
                        select new MatchViewModel
                        {
                            ID = m.ID,
                            TournamentID = t.ID,
                            Fighter1 = m.Fighter1,
                            Fighter2 = m.Fighter2,
                            Tournament = t.Name,
                            StageID = m.StageID,
                            Stage = s.Name,
                            VenueID = m.VenueID,
                            Venue = vn.Name,
                            RoundID = s.RoundID,
                            Round = r.Name,
                            Date = m.Date
                        };

            var matches = query.ToList();

            foreach(var match in matches)
            {
                match.Fighter1Name = _smashDbContext.Characters.SingleOrDefault(c => c.ID == match.Fighter1).Name;
                match.Fighter2Name = _smashDbContext.Characters.SingleOrDefault(c => c.ID == match.Fighter2).Name;
            }

            return matches;
        }

        public List<CharacterModel> GetTopFourCharacters(int inTournamentID)
        {
            var characters = new List<CharacterModel>();

            for(int i=1; i<5; i++)
            {
                var character = _smashDbContext.TournamentRankings.SingleOrDefault(t => t.TournamentID == inTournamentID && t.PositionID == i);
                if(character != null) characters.Add(_smashDbContext.Characters.SingleOrDefault(c => c.ID == character.CharacterID));
            }

            return characters;
        }

        public List<MatchViewModel> GetMatchesByStage(int inTournamentID, int inStageID)
        {
            var query = from m in _smashDbContext.Matches
                        join t in _smashDbContext.Tournaments on m.TournamentID equals t.ID
                        join s in _smashDbContext.TournamentStages on m.StageID equals s.ID
                        join r in _smashDbContext.TournamentRounds on s.RoundID equals r.ID
                        join v in _smashDbContext.Venues on new { Venue = m.VenueID } equals new { Venue = (int?)v.ID } into mv
                        from vn in mv.DefaultIfEmpty()
                        where m.TournamentID == inTournamentID
                        && m.StageID == inStageID
                        select new MatchViewModel
                        {
                            ID = m.ID,
                            TournamentID = t.ID,
                            Fighter1 = m.Fighter1,
                            Fighter2 = m.Fighter2,
                            Score1 = m.Score1,
                            Score2 = m.Score2,
                            Tournament = t.Name,
                            StageID = m.StageID,
                            Stage = s.Name,
                            VenueID = m.VenueID,
                            Venue = vn.Name,
                            RoundID = s.RoundID,
                            Round = r.Name,
                            Date = m.Date,
                            SuddenDeath = m.SuddenDeath
                        };

            var matches = query.ToList();

            foreach (var match in matches)
            {
                match.Fighter1Name = _smashDbContext.Characters.SingleOrDefault(c => c.ID == match.Fighter1).Name;
                match.Fighter2Name = _smashDbContext.Characters.SingleOrDefault(c => c.ID == match.Fighter2).Name;
                if(match.SuddenDeath != null) match.SuddenDeathWinner = _smashDbContext.Characters.SingleOrDefault(c => c.ID == match.SuddenDeath).Name;
            }

            return matches;
        }

        public List<TournamentTableViewModel> CalculateTable(int inTournamentID, int inStageID)
        {
            var query = from m in _smashDbContext.Matches
                          where m.TournamentID == inTournamentID
                          && m.StageID == inStageID
                          select new MatchViewModel
                          {
                              Fighter1 = m.Fighter1,
                              Fighter2 = m.Fighter2,
                              Score1 = m.Score1,
                              Score2 = m.Score2
                          };

            var matches = query.ToList();

            foreach(var match in matches)
            {
                match.Fighter1Name = _smashDbContext.Characters.Single(c => c.ID == match.Fighter1).Name;
                match.Fighter2Name = _smashDbContext.Characters.Single(c => c.ID == match.Fighter2).Name;
            }

            var table = new List<TournamentTableViewModel>();

            var characters =  matches.GroupBy(m => m.Fighter1Name)
                           .Select(grp => grp.First())
                           .ToList();

            foreach (var character in characters)
            {
                table.Add(new TournamentTableViewModel(character.Fighter1Name));
            }

            foreach(var character in table)
            {
                foreach(var match in matches)
                {
                    if(match.Fighter1Name == character.Name) CalculateResult(character, match.Score1, match.Score2);

                    else if (match.Fighter2Name == character.Name) CalculateResult(character, match.Score2, match.Score1);
                }

                character.KOsDifference = character.KOsFor - character.KOsAgainst;
            }

            table = table.OrderByDescending(m => m.Points).ThenByDescending(m => m.KOsDifference).ThenByDescending(m => m.KOsFor).ToList();

            return table;
        }

        public TournamentTableViewModel CalculateResult(TournamentTableViewModel inCharacter, int inScore1, int inScore2)
        {
            inCharacter.Played += 1;

            if (inScore1 > inScore2)
            {
                inCharacter.Points += 3;
                inCharacter.Wins += 1;
            }
            else if (inScore1 == inScore2)
            {
                inCharacter.Points += 1;
                inCharacter.Draws += 1;
            }
            else inCharacter.Losses += 1;

            inCharacter.KOsFor += inScore1;
            inCharacter.KOsAgainst += inScore2;

            return inCharacter;
        }

        public string GetCharacterFinish(int inCharacterID, int inTournamentID)
        {
            var characterWins = _smashDbContext.TournamentRankings.Where(t => t.CharacterID == inCharacterID && t.PositionID == 1 && t.TournamentID <= inTournamentID).ToList();

            return AddOrdinal(characterWins.Count);
        }

        public string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }
    }
}