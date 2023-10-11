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
    public class MovieBusiness:IMovieBusiness
    {
        private IMovieRespository _res;
        public MovieBusiness(IMovieRespository res)
        {
            _res = res;
        }
        public MovieModel getbyID(int id)
        {
            return _res.GetbyID(id);
        }

        public bool Create(MovieModel model)
        {
            return _res.Create(model);
        }

        public bool Update(MovieModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<MovieModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai)
        {
            return _res.Search(pageIndex,pageSize, out total, ten_phim, the_loai);
        }
    }
}
