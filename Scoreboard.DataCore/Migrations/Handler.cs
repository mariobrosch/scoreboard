using System.IO;

namespace Scoreboard.DataCore.Migrations
{
    public class Handler
    {
        public void StartMigrations()
        {
            MigrateGameModel();
        }

        private void MigrateGameModel()
        {
            string localStoragePath = Settings.Logic.GetSetting("localStoragePath");
            string gameFile = Path.Combine(localStoragePath, "Games.json");
            if (!File.Exists(gameFile)) { return; }

            if (File.Exists(gameFile))
            {
                string content = File.ReadAllText(gameFile);
                content = content.Replace("Game", "Set");
                File.WriteAllText(Path.Combine(localStoragePath, "Sets.json"), content);
                File.Delete(gameFile);
            }

            if (File.Exists(Path.Combine(localStoragePath, "MatchTypes.json")))
            {
                string content = File.ReadAllText(Path.Combine(localStoragePath, "MatchTypes.json"));
                content = content.Replace("Game", "Set");
                File.WriteAllText(Path.Combine(localStoragePath, "MatchTypes.json"), content);
            }
            if (File.Exists(Path.Combine(localStoragePath, "SinglePlayerGames.json")))
            {
                File.Copy(Path.Combine(localStoragePath, "SinglePlayerGames.json"), Path.Combine(localStoragePath, "SinglePlayerMatches.json"));
                File.Delete(Path.Combine(localStoragePath, "SinglePlayerGames.json"));
            }
        }
    }
}
