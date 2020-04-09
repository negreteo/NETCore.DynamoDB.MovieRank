using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Contracts;

namespace MovieRank.Services
{
   public interface IMovieRankService
   {
      Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase ();
   }
}
