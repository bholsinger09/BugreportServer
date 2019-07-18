using System;
using System.Collections.Generic;
using System.Data;
using bugserver.Models;
using Dapper;

namespace bugserver.Repositories
{
  public class BugRepository
  {
    private readonly IDbConnection _db;

    public BugRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Bug> GETALL()
    {
      return _db.Query<Bug>("SELECT * FROM bugs");

    }

    public Bug GetById(int id)
    {
      string query = "SELECT * FROM bugs WHERE id = @id";
      Bug bug = _db.QueryFirstOrDefault<Bug>(query, new { id });
      if (bug == null) throw new Exception("Invalid Id");
      return bug;
    }

    public Bug Create(Bug value)
    {
      string query = @"
      INSERT INTO bugs (author, title, details)
      VALUES (@Author, @Title, @Description);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Bug Update(Bug value)
    {
      string query = @"
      UPDATE bus 
      SET 
         author = @Author,
         title = @Title,
         details = @Description
         WHERE ID = @Id;
         SELECT * FROM bugs WHERE id = @Id";
      return _db.QueryFirstOrDefault<Bug>(query, value);



    }

    public string Delete(int id)
    {
      string query = "DELETE FROM bugs WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleed Bug";

    }
  }
}