using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Models
{
    internal class AlbumData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
