﻿using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Custmers { get; set; }
    }
}