using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class ThemeOnVerification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The theme name is missing")]
        public string Name { get; set; }
    }
}
