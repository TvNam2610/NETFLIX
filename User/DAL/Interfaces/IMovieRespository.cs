﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMovieRespository
    {
        List<MovieModel> GetAll();
        MovieModel GetbyID(int id);

        List<MovieModel> GetPopularMovies();
        List<MovieModel> GetSimilarMovies(int id);
        public List<MovieModel> Search(int pageIndex, int pageSize, out long total, string name);

    }
}
