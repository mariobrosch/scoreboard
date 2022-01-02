using Newtonsoft.Json;
using System;

namespace Scoreboard.DataCore.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
    }
}