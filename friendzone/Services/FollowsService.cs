using System.Collections.Generic;
using friendzone.Models;
using friendzone.Repositories;

namespace friendzone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _fr;

    public FollowsService(FollowsRepository fr)
    {
      _fr = fr;
    }


    internal Follow Create(Follow data)
    {
      return _fr.Create(data);
    }

    internal List<Follow> GetProfileFollows(string id)
    {
      return _fr.GetProfileFollows(id);
    }
  }
}