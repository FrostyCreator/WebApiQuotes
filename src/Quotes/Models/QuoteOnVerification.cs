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

        [Required]
        public string Text { get; set; }

        [Required]
        public string Theme { get; set; }
    }
}
