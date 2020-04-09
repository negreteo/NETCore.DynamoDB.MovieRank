using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repository;

namespace MovieRank.Services
{
   public class MovieRankService : IMovieRankService
   {
      private readonly IMovieRankRepository _movieRankRepository;
      private readonly IMapper _map;

      public MovieRankService (IMovieRankRepository movieRankRepository, IMapper map)
      {
         _map = map;
         _movieRankRepository = movieRankRepository;
      }

      public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase ()
      {
         var response = await _movieRankRepository.GetAllItems ();
         return _map.ToMovieContract (response);
      }

   }
}
