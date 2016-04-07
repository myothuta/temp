//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Globalization;
//using System.Web.Mvc;
//using System.Web.Security;
//using System.Linq;

//namespace SMPWebservice.Models
//{

//    public class D3Model
//    {

//        public int id { get; set; }
//        public string name { get; set; }
//        public int size { get; set; }
//        public int depth { get; set; }

//        /* GOT A LOT MORE PROPERTIES IN THIS SPACE */

//        public D3Model parent { get; set; }
//        public List<D3Model> children { get; set; }
//        public List<children> _children { get; set; }

//        public D3Model()
//        {

//        }
//    }

//    public class children
//    {
//        public string name { get; set; }
//        public int size { get; set; }
//        public int id { get; set; }
//        public string Title { get; set; }
//        public string Desc { get; set; }
//        public string ImagePath { get; set; }
//        public string DonorName { get; set; }
//        public string LocationArea { get; set; }
//        public int ViewCount { get; set; }
//        public children()
//        {
//        }
//        public children(string name, string Desc)
//        {
//            this.name = name;
//            this.Desc = Desc;
//        }
//    }

//    public class D3MindMapData
//    {


//        public D3Model d3Root = new D3Model();
//        static int count = 0;

//        public D3MindMapData(SearchResponse Resp, string SearchKey)
//        {

//            d3Root.name = SearchKey;
//            d3Root.children = new List<D3Model>();
//            d3Root.id = count++;
//            d3Root.depth = 0;
//            Dictionary<string, D3Model> categoryMap = new Dictionary<string, D3Model>();
//            foreach (Content c in Resp.Contents)
//            {
//                string desc = c.Desc;
//                IEnumerable<Record> contain = CategoryMappings.Records.Where(x => desc.Contains(x.Keyword));
//                foreach (Record r in contain)
//                {
//                    if (Resp.Statistics.ContainsKey(r.Category))
//                    {
//                        if (!categoryMap.ContainsKey(r.Category))
//                        {
//                            D3Model d3ChildCat = new D3Model();
//                            d3ChildCat.name = r.Category;
//                            d3ChildCat.id = count++;
//                            d3ChildCat.depth = 1;
//                            d3ChildCat._children = new List<children>();
//                            children _child = new children();
//                            _child.Desc = c.Desc;
//                            int maxlength = 100;
//                            maxlength = c.Desc.Length > 100 ? maxlength : c.Desc.Length;
//                            _child.name = c.Desc.Substring(0, maxlength);
//                            _child.Title = c.Title;
//                            _child.ImagePath = c.ImagePath;
//                            _child.id = count++;
//                            _child.LocationArea = c.LocationArea;
//                            _child.ViewCount = c.ViewCount;
//                            _child.DonorName = c.DonorName;
//                            _child.id = count++;
//                            d3ChildCat._children.Add(_child);

//                            d3Root.children.Add(d3ChildCat);

//                            categoryMap.Add(r.Category, d3ChildCat);
//                        }
//                        else
//                        {
//                            D3Model d3ChildCat = new D3Model();
//                            d3ChildCat = categoryMap[r.Category];
//                            children _child = new children();
//                            _child.Desc = c.Desc;
//                            int maxlength = 100;
//                            maxlength = c.Desc.Length > 100 ? maxlength : c.Desc.Length;
//                            _child.name = c.Desc.Substring(0, maxlength);
//                            _child.Title = c.Title;
//                            _child.ImagePath = c.ImagePath;
//                            _child.id = count++;
//                            _child.LocationArea = c.LocationArea;
//                            _child.ViewCount = c.ViewCount;
//                            _child.DonorName = c.DonorName;
//                            _child.id = count++;
//                            d3ChildCat._children.Add(_child);
//                        }

//                        //if (!Resp.statisticsId.ContainsKey(c.Id + r.Category))
//                        //{

//                        //    result.Statistics[r.Category] += 1;
//                        //    result.statisticsId.Add(c.Id + r.Category, "");
//                        //}


//                    }
//                    c.record = r;
//                }
//            }

//            //foreach (var category in Resp.Statistics)
//            //{
//            //    D3Model d3ChildCat = new D3Model();
//            //    d3ChildCat.name = category.Key;
//            //    d3ChildCat.id = count++;
//            //    d3ChildCat.depth = 1;
//            //    IEnumerable<Content> contents = Resp.Contents.Where(x => x.Category == category.Key);
//            //    if (contents.Count() > 0)
//            //    {
//            //        d3ChildCat._children = new List<children>();
//            //        foreach (var v in contents)
//            //        {
//            //            children _child = new children();
//            //            _child.Desc = v.Desc;
//            //            int maxlength = 100;
//            //            maxlength = v.Desc.Length > 100 ? maxlength : v.Desc.Length;
//            //            _child.name = v.Desc.Substring(0, maxlength);
//            //            _child.Title = v.Title;
//            //            _child.ImagePath = v.ImagePath;
//            //            _child.id = count++;
//            //            _child.LocationArea = v.LocationArea;
//            //            _child.ViewCount = v.ViewCount;
//            //            _child.DonorName = v.DonorName;
//            //            _child.id = count++;
//            //            d3ChildCat._children.Add(_child);

//            //        }
//            //    }
//            //    d3Root.children.Add(d3ChildCat);

//            //}

//        }
//    }



//}


﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq;
using System.Text.RegularExpressions;

namespace SMPWebservice.Models
{

    public class D3Model
    {

        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public int depth { get; set; }

        /* GOT A LOT MORE PROPERTIES IN THIS SPACE */

        public D3Model parent { get; set; }
        public List<D3Model> children { get; set; }
        public List<children> _children { get; set; }

        public D3Model()
        {

        }
    }

    public class children
    {
        public string name { get; set; }
        public int size { get; set; }
        public int id { get; set; }
        public string SMPID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImagePath { get; set; }
        public string DonorName { get; set; }
        public string LocationArea { get; set; }
        public int ViewCount { get; set; }
        public children()
        {
        }
        public children(string name, string Desc)
        {
            this.name = name;
            this.Desc = Desc;
        }
    }

    public class D3MindMapData
    {


        public D3Model d3Root = new D3Model();
        static int count = 0;
        public D3MindMapData()
        {
            Dictionary<string, int> Statistics = new Dictionary<string, int>();

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



            d3Root.name = "Festival";
            d3Root.children = new List<D3Model>();
            d3Root.id = count;
            d3Root.depth = 0;
            D3Model parent = d3Root;
            foreach (var category in Statistics)
            {
                D3Model d3ChildCat = new D3Model();
                d3ChildCat.name = category.Key;
                d3ChildCat.id = count++;
                d3Root.depth = 1;

                if (d3ChildCat.name.Contains("name"))
                {
                    d3ChildCat._children = new List<children>();
                    d3Root.depth++;
                    d3ChildCat._children.Add(new children("TESTING " + d3ChildCat.name, "aaddafd"));
                }
                d3Root.parent = parent;
                d3Root.children.Add(d3ChildCat);
            }

        }

        public D3MindMapData(SearchResponse Resp, string SearchKey)
        {

            d3Root.name = SearchKey;
            d3Root.children = new List<D3Model>();
            d3Root.id = count++;
            d3Root.depth = 0;

            foreach (var category in Resp.Statistics)
            {
                D3Model d3ChildCat = new D3Model();
                d3ChildCat.name = category.Key;
                d3ChildCat.id = count++;
                d3ChildCat.depth = 1;
                string SentenceByWord = "";

                IEnumerable<Content> contents = Resp.Contents.Where(x => x.Category == category.Key);
                if (contents.Count() > 0)
                {
                    d3ChildCat._children = new List<children>();
                    foreach (var v in contents)
                    {
                        children _child = new children();
                        _child.Desc = v.Desc;
                        SentenceByWord = GetSentencebyKeyword(_child.Desc,v.KeyWord);
                        int maxlength = 500;
                        maxlength = SentenceByWord.Length > 500 ? maxlength : SentenceByWord.Length;
                        _child.name = SentenceByWord.Substring(0, maxlength);
                        _child.Title = v.Title;
                        _child.ImagePath = v.ImagePath;
                        _child.LocationArea = v.LocationArea;
                        _child.ViewCount = v.ViewCount;
                        _child.DonorName = v.DonorName;
                        _child.id = count++;
                        _child.SMPID = v.Id;
                        d3ChildCat._children.Add(_child);

                    }
                }
                d3Root.children.Add(d3ChildCat);

            }

        }

        public string GetSentencebyKeyword(string sentences,string keyword)
        {
            string resultStr = sentences;
            var r = new Regex("[^.!?;]*(" + keyword + ")[^.!?;]*");
            var m = r.Matches(sentences);

            var result = Enumerable.Range(0, m.Count).Select(index => m[index].Value).ToList();
            if (result.Count > 0)
            {
                resultStr = result.First();
            }

            return resultStr;

        }
    }



}
