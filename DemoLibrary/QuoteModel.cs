using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
   
    public class QuoteModel
    {
        public string quote { get; set; }
        public string length { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }
        public string category { get; set; }
        public string date { get; set; }
        public string permalink { get; set; }
        public string title { get; set; }
        public string background { get; set; }
        public string id { get; set; }
    }

    
}
