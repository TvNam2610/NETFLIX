using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GenreBusiness : IGenreBusiness
    {
        private IGenreRepository _res;
        public GenreBusiness(IGenreRepository res)
        {
            _res = res;
        }
        public List<GenreModel> getAllWithMovie()
        {
            return _res.getAllWithMovie();
        }
    }
}
