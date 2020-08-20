using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models.ReturnedModels
{
    public class ReturnedQuote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string Theme { get; set; }
    }
}
