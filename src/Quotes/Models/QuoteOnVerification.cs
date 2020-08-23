using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class QuoteOnVerification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The quote text is missing")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Missing theme")]
        public string Theme { get; set; }
    }
}
