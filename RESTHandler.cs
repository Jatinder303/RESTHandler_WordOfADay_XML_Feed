using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RESTHandler_WordOfADay_XML_Feed
{
    public class RESTHandler
    {
        private string _url;

        public RESTHandler()
        {
            _url = "";
        }

        public RESTHandler(string url)
        {
            _url = url;
        }

        public async Task<Rss> ExecuteRequestAsync()
        {
            var client = new RestClient(_url);
            var request = new RestRequest();

            RestResponse response = await client.ExecuteAsync(request);

            XmlSerializer serializer = new XmlSerializer(typeof(Rss));
            Rss objRss;

            TextReader sr = new StringReader(response.Content);
            objRss = (Rss)serializer.Deserialize(sr);
            return objRss;
        }

    }
}
