using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace HtmlCrawler
{
    public class Crawler
    {
        public string Url { get; set; }
        public HtmlDocument Document { get; set; }

        public Crawler() { }
        public Crawler(string url)
        {
            Url = url;
            Document = new HtmlWeb().Load(Url);
        }

        public void UpdateDocument(string url)
        {
            Url = url;
            Document = new HtmlWeb().Load(Url);
        }

        public HtmlNode GetElementByClass(string @class)
        {
            if(Document == null)
                Document = new HtmlWeb().Load(Url);
            return Document.DocumentNode
                .Descendants()
                .First(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains(@class));
        }

        public IEnumerable<HtmlNode> GetElementsById(string id)
        {
            if (Document == null)
                Document = new HtmlWeb().Load(Url);
            return Document.DocumentNode
                .Descendants()
                .Where(d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains(id));
        }

        public IEnumerable<HtmlNode> GetElementsByName(string name)
        {
            if (Document == null)
                Document = new HtmlWeb().Load(Url);
            return Document.DocumentNode
                .Descendants()
                .Where(d => d.Attributes.Contains("name") && d.Attributes["name"].Value.Contains(name));
        }
    }
}
