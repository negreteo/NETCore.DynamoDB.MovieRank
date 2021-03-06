using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers
{
   [Route ("movies")]
   public class MovieController : Controller
   {
      private readonly IMovieRankService _movieRankService;

      public MovieController (IMovieRankService movieRankService)
      {
         _movieRankService = movieRankService;
      }

      public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase ()
      {
         var results = await _movieRankService.GetAllItemsFromDatabase ();
         return results;
      }
   }
}
