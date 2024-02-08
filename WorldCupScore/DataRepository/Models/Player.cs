using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataRepo.Models
{
    public class Player : IComparable<Player>
    {
        //quicktype.io

        //name, captain, shirtNr, Pos, fave, img, imgPath, Goals
        // yellowCard, GamesPlayed
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("captain", NullValueHandling = NullValueHandling.Ignore)]
        public bool Captain { get; set; }
        [JsonProperty("shirt_number", NullValueHandling = NullValueHandling.Ignore)]
        public int ShirtNumber { get; set; }
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }
        public bool Favourite { get; set; }

        public PlayerImage Image { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int GamesPlayed { get; set; }

        //player image props

        //default ctor
        public Player()
        {
            Goals = 0;
            YellowCards = 0;
            GamesPlayed = 0;
        }
        // generate compareTo, Equals, HashCode
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   ShirtNumber == player.ShirtNumber &&
                   Goals == player.Goals &&
                   YellowCards == player.YellowCards &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ShirtNumber);
        }

        public  int CompareTo(Player other)
        {
            //compare based on nr, goals, cards (to have stats)
            if (other == null) return 1;
            if (ShirtNumber != other.ShirtNumber) return ShirtNumber.CompareTo(other.ShirtNumber);
            if (Goals!= other.Goals) return Goals.CompareTo(other.Goals);
            return YellowCards.CompareTo(other.YellowCards);
        }
  


    }
}
