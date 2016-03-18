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
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImagePath { get; set; }
        public string DonorName { get; set; }
        public string LocationArea { get; set; }
        public int ViewCount { get; set; }

    }
}
