using System.Data;

namespace bugserver.Repositories
{
  public class BugRepository
  {
    private readonly IDbConnection _db;

    public BugRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}