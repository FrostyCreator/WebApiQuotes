using Quotes.Models.ReturnedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class Theme
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Quote> Quotes { get; set; }


        public static explicit operator ReturnedTheme(Theme theme)
        {
            return new ReturnedTheme()
            {
                Id = theme.Id,
                Name = theme.Name
            };
        }
    }
}
