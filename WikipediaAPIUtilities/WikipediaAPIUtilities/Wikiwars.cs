using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/*
 * TODO General
 * 
 * -> Change output so that it spits out a start page and then an end page
 * -> Ensure program stops when the list is full (perhaps a break;)
 * -> Check when count = 0 (as in no links)
 * -> Is the _continue flag really needed?
 * -> Check if listOfLinks has atleast 50 in each page
 * 
 * TODO Performance Enhancement
 * 
 * -> Reduce connection to Wikipedia (i.e. Batch results or more than the current max)
 * 
 * TODO Refactoring
 * 
 * -> Move code into classes or atleast don't have the current methods rely on eachother 
 *  so much as it's a twisted loop in the end
 * 
 * TODO Filters/Query String
 * 
 * -> Add filter in query string to remove remaing soddy pages such as list pages (maybe 
 *  check if _nextName or Title starts with List)
 * 
 * -> Attempt to Parse the Title or _nextName with a Date library to check if it is a 
 *  date page (Removes specific dates from results)
 * 
 */

namespace WikipediaAPIUtilities
{
    class Wikiwars
    {
        private Random _r;
        private string _url, _nextPage, _continueToken;
        private bool _continue;
        private ArrayList _listOfPageLinks, _listOfPages;

        public Wikiwars()
        {
            _r = new Random();

            _nextPage = "United States";
            _continueToken = "0|6503";
            _url =
                "https://en.wikipedia.org/w/api.php?action=query&list=backlinks&blnamespace=0&blfilterredir=nonredirects&format=json&bllimit=max&bltitle=" + _nextPage + "&blcontinue=" + _continueToken + "";

            //"https://en.wikipedia.org/w/api.php?action=query&list=random&rnlimit=1&rnnamespace=0&rnfilterredir=nonredirects"; Used to get Random page

            _continue = true;
            _listOfPageLinks = new ArrayList();
            _listOfPages = new ArrayList();

            GetNextPage();

        }

        private string GetNextUrl()
        {
            if (_continueToken.Length < 1)
            {
                _url = "https://en.wikipedia.org/w/api.php?action=query&list=backlinks&bllimit=max&bllimit=max&blnamespace=0&blfilterredir=nonredirects&format=json&bltitle=" + _nextPage + "";
                AddToListOfPages();
            }
            else
            {
                _url = "https://en.wikipedia.org/w/api.php?action=query&list=backlinks&bllimit=max&blnamespace=0&bllimit=max&blfilterredir=nonredirects&format=json&bltitle=" + _nextPage + "&blcontinue=" + _continueToken + "";
            }
            // Console.WriteLine(_url);
            GetNextPage();
            return _url;
        }

        /*
         * Selects the next page to find links
         */
        private string GetNextPage()
        {
            //_url = GetNextUrl();
            var json = _download_serialized_json_data<JSON>(_url);
            GetLinks(json);
            return _nextPage;
        }

        private void GetLinks(JSON json)
        {
            foreach (Backlink t in json.Query.Backlinks)
            {
                _listOfPageLinks.Add(t.Title);
            }
            try
            {
                _continueToken = json.Continue.Blcontinue;
                _continue = true;
            }
            catch (Exception)
            {
                _continueToken = "";
                _continue = false;
            }

            GetNextUrl();
        }

        private void AddToListOfPages()
        {
            _nextPage = _listOfPageLinks[_r.Next(_listOfPageLinks.Count)].ToString();
            _listOfPages.Add(_nextPage);

            foreach (object t in _listOfPageLinks)
            {
                Console.WriteLine(t);

            }
            Console.WriteLine(_listOfPageLinks.Count);
            Console.Read();
            //   if (_listOfPages.Count == 10)
            //   {
            //      foreach (object t in _listOfPages)
            //                   {
            //            Console.WriteLine(t);

            //                    }
            //        //       Console.Read();
            //   }

            _listOfPageLinks.Clear();
        }

        /*
         * Used to create JSON objects from a URL
         */
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var jsonData = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    jsonData = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
            }
        }


    }
}
