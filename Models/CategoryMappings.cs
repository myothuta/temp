<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Web;
using System.Data;

namespace SMPWebservice.Models
{    
    public static class CategoryMappings
    {
        public static List<Record> Records = new List<Record>();

        static CategoryMappings()
        {
            XmlDocument doc = new XmlDocument();

            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/CategoryMappings.xml");
            DataSet data = new DataSet();
            data.ReadXml(xmlData);
            doc.Load(xmlData);
              XmlNodeList elemList = doc.GetElementsByTagName("Row");
              for (int i = 0; i < elemList.Count; i++)
              {
                  Records.Add(new Record() { Keyword = elemList[i].Attributes[0].Value, Category = elemList[i].Attributes[1].Value });
              }            
      
        }
     
             
    }
    public class Record {
        public string Keyword { get; set; }
        public string Category { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Web;
using System.Data;

namespace SMPWebservice.Models
{    
    public static class CategoryMappings
    {
        public static List<Record> Records = new List<Record>();

        static CategoryMappings()
        {
            XmlDocument doc = new XmlDocument();

            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/CategoryMappings.xml");
            DataSet data = new DataSet();
            data.ReadXml(xmlData);
            doc.Load(xmlData);
              XmlNodeList elemList = doc.GetElementsByTagName("Row");
              for (int i = 0; i < elemList.Count; i++)
              {
                  Records.Add(new Record() { Keyword = elemList[i].Attributes[0].Value, Category = elemList[i].Attributes[1].Value });
              }            
      
        }
     
             
    }
    public class Record {
        public string Keyword { get; set; }
        public string Category { get; set; }
    }
}
>>>>>>> origin/master
