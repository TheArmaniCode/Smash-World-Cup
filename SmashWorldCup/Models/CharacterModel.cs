namespace SmashWorldCup.Models
{
    public class CharacterModel
    {
        public int ID { get; set; }
        public int? Rank { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int GameID { get; set; }
        public int Host { get; set; }
        public int Wins { get; set; }
        public string? Logo { get; set; }
        public string? Color { get; set; }
        public string? TextColor { get; set; }
    }
}
