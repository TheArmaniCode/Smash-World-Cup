namespace SmashWorldCup.Models
{
    public class TournamentRankingModel
    {
        public int ID { get; set; }
        public int CharacterID { get; set; }
        public int TournamentID { get; set; }
        public string? Rank { get; set; }
        public int PositionID { get; set; }
        public bool Host { get; set; }
    }
}
