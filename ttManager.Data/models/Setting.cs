using Newtonsoft.Json;

namespace ttManager.Data.models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        [JsonIgnore]
        public string PossibleValues { get; set; }
    }
}
