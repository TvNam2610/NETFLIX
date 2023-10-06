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
    }
}
