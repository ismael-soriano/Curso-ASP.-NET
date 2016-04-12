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
        const string CONFIG_FILE = "config.json";
        const string PROPERTY_CONNECTION_TYPE = "ConnectionType";
        static readonly Config _instance;
        public static Config Instance { get {
            return _instance;
        } }

        [JsonProperty("ConnectionType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ConnectionType ConnectionType { get; private set; }

        [JsonProperty("connectionString", Required = Required.Always)]
        public string ConnectionString { get; private set; }

        static Config()
        {
            _instance = getInstance();
        }

        private Config() {}

        public static Config getInstance() {
            var json = File.ReadAllText(CONFIG_FILE);
            return JsonConvert.DeserializeObject<Config>(json);
        }

    }
}
