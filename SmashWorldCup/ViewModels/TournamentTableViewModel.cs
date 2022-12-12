namespace SmashWorldCup.ViewModels
{
    public class TournamentTableViewModel
    {
        public TournamentTableViewModel(string inName, int inStageID, string inStage)
        {
            Name = inName;
            StageID = inStageID;
            Stage = inStage;
        }
        public string Name { get; set; }
        public int StageID { get; set; }
        public string Stage { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public int KOsFor;

        public int KOsAgainst;

        public int KOsDifference;
        public int Points { get; set; }
    }
}
