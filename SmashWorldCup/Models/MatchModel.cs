namespace SmashWorldCup.Models
{
    public class MatchModel
    {
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public int StageID { get; set; }
        public int? VenueID { get; set; }
        public int Fighter1 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Fighter2 { get; set; }
        public DateTime? Date { get; set; }
        public int? SuddenDeath { get; set; }
    }
}
