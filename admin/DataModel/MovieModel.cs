using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class MovieModel
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public string VideoURL { get; set; }
        public int Duration { get; set; }
        public int AgeRecommend { get; set; }
        public string MovieNameURL { get; set; }
        public string TrailerURL { get; set; }
        public string Genre { get; set; }
        public int ViewCount { get; set; }
        public List<MovieActorsModel> list_json_MovieActors { get; set; }
        public List<MovieDirectors> list_json_MovieDirectors { get; set; }
    }
   

    public class MovieActorsModel 
    {
        public string Actor { get; set; }
    }

    public class MovieDirectors
    {
        public string Director { get;set; }
    }
}
