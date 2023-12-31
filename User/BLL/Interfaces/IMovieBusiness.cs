﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMovieBusiness
    {
        List<MovieModel> getAll();
        List<MovieModel> GetPopularMovies();
        MovieModel getbyID(int id);
        List<MovieModel> GetSimilarMovies(int id);

        public List<MovieModel> Search(int pageIndex, int pageSize, out long total, string name);

    }
}
