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
        public Dictionary<string, string> statisticsId = new Dictionary<string, string>();
        [XmlIgnore]
        public List<string> keywords { get; set; }
        public SearchResponse() {
            keywords = new List<string>();
            Statistics = new Dictionary<string, int>();
            Statistics.Add("Cultural Attribute", 0);
            Statistics.Add("Date", 0);
            Statistics.Add("Definition", 0);
            Statistics.Add("Experience/Memory", 0);
            Statistics.Add("Frequency", 0);
            Statistics.Add("Interesting Fact", 0);
            Statistics.Add("Location", 0);
            Statistics.Add("Name", 0);
            Statistics.Add("Significance", 0);
            Statistics.Add("Timeline", 0);
            Statistics.Add("Wish", 0);

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
        public string Category { get; set; }
        public string KeyWord { get; set; }
    }
}
