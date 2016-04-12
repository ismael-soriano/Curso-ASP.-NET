using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAO
{
    public class Config
    {
        static readonly Config _instance;
        public static Config Instance { get {
            return _instance;
        } }

        [JsonProperty("ConnectionType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConnectionType ConnectionType { get; private set; }

        static Config()
        {
            _instance = getInstance();
        }

        private Config() {}

        public static Config getInstance() {
            var json = File.ReadAllText("config.json");
            return JsonConvert.DeserializeObject<Config>(json);
        }

    }
}
