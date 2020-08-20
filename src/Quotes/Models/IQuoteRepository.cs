﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }
        IQueryable<Theme> Themes { get; }
    }
}
