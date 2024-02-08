using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.DAO
{
    public class AppSettingsRepo
    {
        private static string filePath = @"..\..\..\..\settings.json";

        public AppSettings Load()
        {
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<AppSettings>(json, settings);
        }

        public void Save(AppSettings settings)
        {
            var serialized = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filePath, serialized);
        }
    }
}
