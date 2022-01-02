namespace Scoreboard.DataCore.Models
{
    public class StatsModel
    {
        public string KeyValue { get; set; }
        public int KeyId { get; set; }
        public string ValueAsString { get; set; }
        public int ValueAsInt { get; set; }
        public decimal ValueAsDecimal { get; set; }
    }
}
