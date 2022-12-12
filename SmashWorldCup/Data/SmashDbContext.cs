using Microsoft.EntityFrameworkCore;
using SmashWorldCup.Models;

namespace SmashWorldCup.Data
{
    public class SmashDbContext : DbContext
    {
        public SmashDbContext(DbContextOptions<SmashDbContext> options)
    : base(options)
        {

        }

        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<MatchModel> Matches { get; set; }
        public DbSet<PostitionModel> Positions { get; set; }
        public DbSet<TournamentModel> Tournaments { get; set; }
        public DbSet<TournamentRankingModel> TournamentRankings { get; set; }
        public DbSet<TournamentRoundModel> TournamentRounds { get; set; }
        public DbSet<TournamentStageModel> TournamentStages { get; set; }
        public DbSet<VenueModel> Venues { get; set; }
    }
}
