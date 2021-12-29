namespace Scoreboard.DataCore.Models
{
    public class Set
    {
        public int Id { get; set; }
        public int SetNumber { get; set; }
        public int TeamLeftScore { get; set; }
        public int TeamRightScore { get; set; }
        public int? SetWinnerId { get; set; }
        public int? SetWinnerId2 { get; set; }
        public int MatchId { get; set; }
    }
}
