﻿using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EpisodeBusiness : IEpisodeBusiness
    {
        private IEpisodeRepository _res;
        public EpisodeBusiness(IEpisodeRepository res)
        {
            _res = res;
        }

       

        public EpisodeModel GetbyID(int id)
        {
            return _res.GetbyID(id);
        }

        public List<EpisodeModel> Search(int pageIndex, int pageSize, out long total, string ten_phim, string the_loai)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_phim, the_loai);
        }

      
    }
}
