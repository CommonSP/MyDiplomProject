using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDiplomProject.Models
{
    public class SendMessage
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }
}