using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMPWebservice.Models;
using System.Web.Helpers;

namespace SMPWebservice.Controllers
{
    public class D3Controller : Controller
    {
        //
        // GET: /D3/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetD3Data()
        {
            string text = Session["text"].ToString();
            SearchResponse returnResult = new SearchResponse();
            SearchResponse response = null;
            if (Convert.ToBoolean(Session["category"]))
            {
                response = Session["searchResponseCategory"] as SearchResponse;
            }
            else
            {
                response = WebCache.Get("searchResponse" + text);
            }

            SearchResponse result = new SearchResponse();
            
            
            returnResult.keywords = new List<string>();
            List<Content> contents = new List<Content>();
            int totalRecords = 0;

            if (response == null) return new JsonResult();

            foreach (var category in response.Statistics)
            {
                foreach (Content c in response.Contents)
                {
                    string desc = c.Desc;

                    IEnumerable<Record> contain = CategoryMappings.Records.Where(x => desc.Contains(x.Keyword));
                    foreach (Record r in contain)
                    {
                        if (r.Category == category.Key)
                        {
                            Content copyContent = new Content();
                            copyContent.Desc = desc.Replace(r.Keyword, "<span class='post-tag'>" + r.Keyword + "</span>");
                            copyContent.DonorName = c.DonorName;
                            copyContent.Id = c.Id;
                            copyContent.ImagePath = c.ImagePath;
                            copyContent.LocationArea = c.LocationArea;
                            copyContent.record = c.record;
                            copyContent.Title = c.Title;
                            copyContent.ViewCount = c.ViewCount;
                            copyContent.Category = category.Key;
                            contents.Add(copyContent);
                            totalRecords += 1;
                            if (!returnResult.keywords.Contains(r.Keyword))
                                returnResult.keywords.Add(r.Keyword);
                        }
                    }

                }
            }
            returnResult.StartPosition = 1;
            returnResult.CurrentPosition = 1;
            returnResult.TotalRecords = totalRecords;
            returnResult.Statistics = response.Statistics;
            returnResult.Contents = contents.ToArray();

            D3MindMapData d3Data = new D3MindMapData(returnResult, "CNY");
            return Json(d3Data, JsonRequestBehavior.AllowGet);
        }
    }
}
