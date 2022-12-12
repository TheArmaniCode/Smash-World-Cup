namespace SmashWorldCup.ViewModels
{
    public class TournamentTableViewModel
    {
        public TournamentTableViewModel(string inName/*, int inPlayed, int inWins, int inDraws, int inLosses, int inKOsFor, int inKOsAgainst, int inKOsDifference, int inPoints*/)
        {
            Name = inName;
            //Played = inPlayed;
            //Wins = inWins;
            //Draws = inDraws;
            //Losses = inLosses;
            //KOsFor = inKOsFor;
            //KOsAgainst = inKOsAgainst;
        }
        public string Name { get; set; }
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
