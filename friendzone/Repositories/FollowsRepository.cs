using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using friendzone.Models;

namespace friendzone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;

    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Follow Create(Follow data)
    {
      string sql = @"
      INSERT INTO follows
      (followerId, followingId)
      VALUES
      (@FollowerId, @FollowingId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    internal List<Follow> GetProfileFollows(string id)
    {
      string sql = @"
      SELECT * FROM follows 
      WHERE followingId = @id;
      ";
      return _db.Query<Follow>(sql, new { id }).ToList();
    }
  }
}