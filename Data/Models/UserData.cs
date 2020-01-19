using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Models
{
    internal class UserData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }

    }

    internal class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zip { get; set; }

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; }
    }

    internal class Geo
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lng")]
        public string Longitude { get; set; }
    }

    internal class Company
    {
        [JsonPropertyName("phone")]
        public string Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string BS { get; set; }
    }
}
