using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.DAO
{
    public class AppSettings
    {
        [JsonProperty("championship")]
        public string Championship { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("offline_mode")]
        public bool OfflineMode { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("favorite_team")]
        public string FavoriteTeam { get; set; }

        public AppSettings(string championship, string language, bool offlineMode)
        {
            Championship = championship;
            Language = language;
            OfflineMode = offlineMode;
            Resolution = "medium";
            FavoriteTeam = FavoriteTeam;
        }

        public AppSettings()
        {
            Championship = "men";
            Language = "hr";
            OfflineMode = false;
            Resolution = "medium";
            FavoriteTeam = "";
        }
    }
}
