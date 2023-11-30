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
        public List<MovieDto> list_json_Movies { get; set; } 
        public List<EpisodeActors> list_json_EpisodeActors { get; set; }
        public List<EpisodeDirectors> list_json_EpisodeDirectors { get; set; }
    }
    public class MovieDto
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string CoverImageURL { get; set; }
        public string VideoURL { get; set; }
        public int Duration { get; set; }
        public string MovieNameURL { get; set; }
        public string TrailerURL { get; set; }
    }
    public class EpisodeActors
    {
        public string Actor { get; set; }
    }

    public class EpisodeDirectors
    {
        public string Director { get; set; }
    }
}
