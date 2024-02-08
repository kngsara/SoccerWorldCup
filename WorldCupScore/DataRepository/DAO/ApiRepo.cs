using DataRepo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.DAO
{
    public class ApiRepo : IDataRepo
    {
        private const string BASE_URL = "https://worldcup-vua.nullbit.hr/";
        private const string RESULTS_URL = "/teams/results";
        private const string MATCHES_URL = "/matches";

        public ISet<Matches> GetAllMatches(string championship)
        {
            string url = BASE_URL + championship + MATCHES_URL;
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            var apiClient = new RestClient(BASE_URL);
            var response = apiClient.Execute<List<Matches>>(new RestRequest(url, Method.Get));
            var result = JsonConvert.DeserializeObject<List<Matches>>(response.Content);
            return new HashSet<Matches>(result); //stackoverflow, ne moze vratiti result jer je apstrakcija
        }

        public ISet<Results> GetAllResults(string championship)
        {
            string url = BASE_URL + championship + RESULTS_URL;
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            var apiClient = new RestClient(BASE_URL);
            var response = apiClient.Execute<List<Results>>(new RestRequest(url, Method.Get));
            var result = JsonConvert.DeserializeObject<List<Results>>(response.Content);
            return new HashSet<Results>(result);
        }
    }
}
