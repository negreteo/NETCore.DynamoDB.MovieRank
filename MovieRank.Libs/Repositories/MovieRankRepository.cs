using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MovieRank.Libs.Models;
using MovieRank.Libs.Repository;

namespace MovieRank.Libs.Repositories
{
   public class MovieRankRepository : IMovieRankRepository
   {
      private readonly DynamoDBContext _context;

      public MovieRankRepository (IAmazonDynamoDB dynamoDBClient)
      {
         _context = new DynamoDBContext (dynamoDBClient);
      }

      public async Task<IEnumerable<MovieDb>> GetAllItems ()
      {
         return await _context.ScanAsync<MovieDb> (new List<ScanCondition> ()).GetRemainingAsync ();
      }

   }
}
