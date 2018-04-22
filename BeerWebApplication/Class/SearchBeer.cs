using System.Collections.Generic;

namespace BeerWebApplication.Class
{
    public class SearchGrid
    {
        public int page { get; set; }
        public string sord { get; set; }
        public int rows { get; set; }
        public string sidx { get; set; }

        public string filters { get; set; }

    }
    public class Rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }

    public class Filter
    {
        public string groupOp { get; set; }
        public List<Rule> rules { get; set; }
    }
}