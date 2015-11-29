using System;
using System.Net;
using System.IO;

namespace WikipediaAPIUtilities
{
    class HTML
    {
        public HTML()
        {
            showOptions();
        }

        private void showOptions()
        {
            Console.WriteLine("Starting HTML");
            Console.WriteLine();
            Console.WriteLine("Please enter a search query");
            string _query = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Are you happy about your search for '" + _query + "' ?");
            ConsoleKeyInfo _choice = Console.ReadKey();
            string _strChoice = _choice.KeyChar.ToString();
            confirmQuery(_strChoice, _query);
        }

        private void confirmQuery(string _strChoice, string _query)
        {
            Console.Clear();
            if (_strChoice == "y" || _strChoice == "Y")
            {
                Console.WriteLine("Press any button to continue..");
                Console.ReadLine();
                string result = requestHTML(_query);
                Console.WriteLine(result);
                Console.Read();
                string s = decodeHTML(result);
                Console.WriteLine(s);
                Console.Read();
                string t = encodeHTML(result);
                Console.WriteLine(t);
                Console.Read();
            }
            else if (_strChoice == "n" || _strChoice == "N")
            {
                showOptions();
            }
            else
            {
                Console.WriteLine("'" + _strChoice + "' is not a valid input, please try again.");
                Console.WriteLine();
                showOptions();
            }
        }

        private string requestHTML(string query)
        {
            // Create a request for the URL.        
            WebRequest request = WebRequest.Create("https://en.wikipedia.org/wiki/" + query);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Return the WebRequest
            try
            {
                return getHTML(request);
            }
            catch
            {
                return "Getting the HTTP response Failed.";
            }
        }

        private string getHTML(WebRequest request)
        {
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Return the response.
            try {
                return streamHTML(response); ;
            }
            catch
            {
                return "Streaming the HTML Failed.";
            }
        }

        private string streamHTML(HttpWebResponse response)
        {
            // Get the stream containing content returned by the server.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    // Read the content.
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    //Console.WriteLine(responseFromServer);
                    // Return the streamed content.
                    return responseFromServer;
                }
            }
        }

        private string decodeHTML(string html)
        {
            //Server.HtmlDecode(html); //Can use this in ASP.NET work
            string result = WebUtility.HtmlDecode(html);
            return result;
        }

        private string encodeHTML(string html)
        {
            //Server.HtmlEncode(); //Can use this in ASP.NET work
            string result = WebUtility.HtmlEncode(html);
            return result;
        }
    }
}