using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SMPWebservice.Models
{
    [XmlRoot(Namespace = "http://ws.nlb.gov.sg/M/SM")]
    public class SearchResponse
    {
        [XmlIgnore]
        public Dictionary<string, int> Statistics { get; set; }
        [XmlIgnore]
        public List<string> keywords { get; set; }
        public SearchResponse() {
            keywords = new List<string>();
            Statistics = new Dictionary<string, int>();
            Statistics.Add("Current name", 0);
            Statistics.Add("Alternative name", 0);
            Statistics.Add("Definition", 0);
            Statistics.Add("Cultural Significance", 0);
            Statistics.Add("Social significance [in people’s lives]", 0);
            Statistics.Add("Experience/memory", 0);
            Statistics.Add("Origin story", 0);
            Statistics.Add("Typical date", 0);
            Statistics.Add("Frequency", 0);
            Statistics.Add("Associated people group", 0);
            Statistics.Add("Associated activity/event", 0);
            Statistics.Add("Program item", 0);            
            Statistics.Add("Related festival", 0);
            Statistics.Add("Interesting fact", 0);
            Statistics.Add("Date of origin", 0);
            Statistics.Add("Date of termination", 0);
            Statistics.Add("Date-significant feature", 0);
            Statistics.Add("Development over time", 0);
            Statistics.Add("Date-particular celebration", 0);
            Statistics.Add("Associated belief", 0);
            Statistics.Add("Associated food", 0);
            Statistics.Add("Associated object", 0);
            Statistics.Add("Associated attire", 0);
            Statistics.Add("Nationalistic/cultural element", 0);

        }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int TotalRecords { get; set; }
        public int NextRecordPosition { get; set; }
        public int StartPosition { get; set; }
        public int CurrentPosition { get; set; }
        public Content[] Contents { get; set; } 
       

    }
    public class Content
    {
        public Content() {
            record = new Record();
        }       
        public Record record { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImagePath { get; set; }
        public string DonorName { get; set; }
        public string LocationArea { get; set; }
        public int ViewCount { get; set; }

    }
}
