using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class EpisodeModel
    {
        public int EpisodeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageURL { get; set; }
        public string MovieNameURL { get; set; }
        public string TrailerURL { get; set; }
        public int AgeRecommend { get; set; }
        public string Genre { get; set; } // Lấy về thể loại của seris phim
        public int ViewCount { get; set; }
        public List<MovieModel> list_json_Movies { get; set; } // Lấy về list json của những tập phim có trong seris
        
    }
    
}
