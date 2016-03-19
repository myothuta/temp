using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using SMPWebservice.Models;
using System.Web.Helpers;

namespace SMPWebservice.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search(string text)
        {
            Session["text"] = text;
            SearchResponse result = new SearchResponse();
            SearchResponse returnResult = new SearchResponse();
            result = WebCache.Get("searchResponse" + text);
            if (result == null)
            {
                result = new SearchResponse();
                XmlSerializer serializer = new XmlSerializer(typeof(SearchResponse));

                int nextStartPosition = 0;
                Content[] storeContents = new Content[0];
                decimal pages = 0;

                HttpWebRequest request = WebRequest.Create("http://openweb-stg.nlb.gov.sg/REST/SM2/contents/search?tags=" + text + "&max=30&start=1") as HttpWebRequest;
                request.Headers.Add("X-Authorization", "Q2hyaXN0b3BoZXJLaG9vU29vR3VhbjpDaHIhc2kwcGhAUmswOTg=");
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result = serializer.Deserialize(reader) as SearchResponse;
                    storeContents = result.Contents;
                }

                if (result.TotalRecords > 0)
                {
                    pages = Decimal.Ceiling(Convert.ToDecimal(result.TotalRecords) / 30);
                    nextStartPosition = 31;
                }

                for (int i = 1; i < pages; i++)
                {
                    request = WebRequest.Create("http://openweb-stg.nlb.gov.sg/REST/SM2/contents/search?tags=" + text + "&max=30&start=" + nextStartPosition) as HttpWebRequest;
                    request.Headers.Add("X-Authorization", "Q2hyaXN0b3BoZXJLaG9vU29vR3VhbjpDaHIhc2kwcGhAUmswOTg=");
                    response = request.GetResponse() as HttpWebResponse;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = serializer.Deserialize(reader) as SearchResponse;
                        storeContents = storeContents.Union(result.Contents).ToArray();
                    }

                    nextStartPosition += 30;
                }


                result.Contents = storeContents;

                WebCache.Set("searchResponse" + text, result);
            }

            returnResult.StartPosition = 1;
            returnResult.CurrentPosition = 1;
            returnResult.TotalRecords = result.TotalRecords;
            Content[] returnContents = new Content[10];
            if (returnResult.TotalRecords < 10) {
                returnContents = new Content[returnResult.TotalRecords];
            }
            for (int i = 0; i < returnContents.Length; i++)
            {
                returnContents[i] = result.Contents[i];
            }
            returnResult.Contents = returnContents;


            return PartialView(returnResult);
        }

        public ActionResult Navigate(int start,int index,string command)
        {
            string text = Session["text"].ToString();
            SearchResponse returnResult = new SearchResponse();
            var result = WebCache.Get("searchResponse" + text);
            returnResult.StartPosition = start;
            returnResult.CurrentPosition = index;
            returnResult.TotalRecords = result.TotalRecords;
            decimal pages = Decimal.Ceiling(Convert.ToDecimal(returnResult.TotalRecords) / 10);

            int from = (index*10)-10 ;
            int to = (index * 10);
            if (to > result.TotalRecords) to = result.TotalRecords;
            if (from > to) {
                from = (Convert.ToInt32(pages)-1)*10;
                returnResult.CurrentPosition = Convert.ToInt32(pages);
            }
            Content[] returnContents = new Content[to-from];
            int current = 0;
            for (int i = from; i < to; i++)
            {
                returnContents[current] = result.Contents[i];
                current++;
            }
            returnResult.Contents = returnContents;
            

            if (command=="next")
            {
                if (returnResult.TotalRecords > 0)
                {
                  
                    if (pages >= start + 10)
                    {
                        returnResult.StartPosition += 10;
                    }
                }
            }
            //if (command == "previous")
            //{
            //    returnResult.StartPosition += 10;
            //}
            return PartialView("Search",returnResult);
        }

        public ActionResult Pager(int start)
        {
            var searchResponse = WebCache.Get("searchResponse");
            decimal pages = 0;
            if (searchResponse.TotalRecords > 0)
            {
                pages = Decimal.Ceiling(Convert.ToDecimal(searchResponse.TotalRecords) / 10);
                if (pages >= start +10)
                {
                    searchResponse.StartPosition += 10;
                }
            }
            return PartialView(searchResponse);
        }

    }
}
