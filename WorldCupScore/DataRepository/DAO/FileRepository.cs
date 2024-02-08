using DataRepo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataRepo.DAO
{
    public class FileRepository : IDataRepo
    {
        private static string filePath = @"..\..\..\DataRepository\worldcup.sfg.io\";
        // relative path to "group_results.json"
        private const string GROUP_RESULTS_FILE_PATH = @"\group_results.json";
        // relative path to "matches.json"
        private const string MATCHES_FILE_PATH = @"\matches.json";
        // relative path to "results.json"
        private const string RESULTS_FILE_PATH = @"\results.json";
        // relative path to "teams.json"
        private const string TEAMS_FILE_PATH = @"\teams.json";
        

        ISet<Matches> IDataRepo.GetAllMatches(string championship)
        {
            string json = File.ReadAllText(filePath + championship + MATCHES_FILE_PATH);
            return JsonConvert.DeserializeObject<ISet<Matches>>(json, Converter.JsonSet);
        }

        ISet<Results> IDataRepo.GetAllResults(string championship)
        {
            string json = File.ReadAllText(filePath + championship + RESULTS_FILE_PATH);
            return JsonConvert.DeserializeObject<ISet<Results>>(json, Converter.JsonSet);
        }
    }
}
