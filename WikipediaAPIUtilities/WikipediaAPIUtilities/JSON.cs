using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikipediaAPIUtilities
{
    class JSON
    {
        public string Batchcomplete { get; set; }
        public Continue Continue { get; set; }
        public Limits Limits { get; set; }
        public Query Query { get; set; }
    }
    public class Continue
    {
        public string Blcontinue { get; set; }
        public string _continue { get; set; }
    }

    public class Limits
    {
        public int Backlinks { get; set; }
    }

    public class Query
    {
        public Backlink[] Backlinks { get; set; }
    }

    public class Backlink
    {
        public int Pageid { get; set; }
        public int Ns { get; set; }
        public string Title { get; set; }
    }
}

