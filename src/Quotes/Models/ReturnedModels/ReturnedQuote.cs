using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models.ReturnedModels
{
    public class ReturnedQuote
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public ReturnedTheme Theme { get; set; }
    }
}
