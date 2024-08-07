using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Models
{
    internal class CityData
    {
        using System;
using System.Collections.Generic;
using Newtonsoft.Json; // Assurez-vous d'ajouter le package Newtonsoft.Json via NuGet

public class FeatureCollection
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }

    public class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Properties
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("citycode")]
        public string Citycode { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("importance")]
        public double Importance { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }
    }

    public class Filters
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }


}
