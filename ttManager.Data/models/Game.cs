namespace ttManager.Data.models
{
    public class Game
    {
        public int Id { get; set; }
        public int GameNumber { get; set; }
        public int TeamLeftScore { get; set; }
        public int TeamRightScore { get; set; }
        public int? GameWinnerId { get; set; }
        public int? GameWinnerId2 { get; set; }
        public int MatchId { get; set; }
    }
}
