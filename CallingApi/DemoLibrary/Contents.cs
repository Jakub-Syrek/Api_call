using System.Collections.Generic;

namespace DemoLibrary
{
    public class Contents<T>
    {
        public IEnumerable<QuoteModel> quotes { get; set; }
    }
}