﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Exceptions
{
    public class DuplicateMovieException : Exception
    {
        public DuplicateMovieException(string message) : base(message) { }
    }
}
