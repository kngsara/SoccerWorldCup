using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataRepo.Models
{
    public class Results : IComparable<Results>
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
        [JsonProperty("alternate_name", NullValueHandling = NullValueHandling.Ignore)]
        public object Alternate_name { get; set; }
        [JsonProperty("fifa_code", NullValueHandling = NullValueHandling.Ignore)]
        public string Fifa_code { get; set; }
        [JsonProperty("group_id", NullValueHandling = NullValueHandling.Ignore)]
        public int Group_id { get; set; }
        [JsonProperty("group_letter", NullValueHandling = NullValueHandling.Ignore)]
        public string Group_letter { get; set; }
        [JsonProperty("wins", NullValueHandling = NullValueHandling.Ignore)]
        public int Wins { get; set; }
        [JsonProperty("draws", NullValueHandling = NullValueHandling.Ignore)]
        public int Draws { get; set; }
        [JsonProperty("losses", NullValueHandling = NullValueHandling.Ignore)]
        public int Losses { get; set; }
        [JsonProperty("games_played", NullValueHandling = NullValueHandling.Ignore)]
        public int Games_played { get; set; }
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int Points { get; set; }
        [JsonProperty("goals_for", NullValueHandling = NullValueHandling.Ignore)]
        public int Goals_for { get; set; }
        [JsonProperty("goals_against", NullValueHandling = NullValueHandling.Ignore)]
        public int Goals_against { get; set; }
        [JsonProperty("goal_differential", NullValueHandling = NullValueHandling.Ignore)]
        public int Goal_differential { get; set; }


        //comparing results by its parameters (id, code, groupId)
        public int CompareTo(Results other)
        {
            if (other is null) return 1;
            if (Id > other.Id) return 1;
            if (Id < other.Id) return -1;
            if (Fifa_code is null) return 1;
            if (other.Fifa_code is null) return -1;
            if (Fifa_code.CompareTo(other.Fifa_code) > 0) return 1;
            if (Fifa_code.CompareTo(other.Fifa_code) < 0) return -1;
            if (Group_id > other.Group_id) return 1;
            if (Group_id < other.Group_id) return -1;
            return 0;
        }

        //for comparation purposes, dont need to create an object
        //so only default ctor

        public override bool Equals(object obj)
        {
            return obj is Results results &&
                   Id == results.Id &&
                   Fifa_code == results.Fifa_code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Fifa_code);
        }

        //tostring() for showing comparation
        public override string ToString()
        {
            return $"{Id}, {Country}, {Alternate_name}, {Fifa_code}, {Group_id}, {Group_letter}, " +
            $"{Wins}, {Draws}, {Losses}, {Games_played}, {Points}, {Goals_against}, {Goal_differential}.";
        }


    }
}
