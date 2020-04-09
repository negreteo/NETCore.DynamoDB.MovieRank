using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repository
{
   public interface IMovieRankRepository
   {
      Task<IEnumerable<MovieDb>> GetAllItems ();
   }
}
