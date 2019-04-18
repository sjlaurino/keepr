using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = false");
    }

    public IEnumerable<Keep> GetAllPrivate(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }

    public Keep FindById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id", new { id });
    }

    public Keep CreateKeep(Keep keepData)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps(name, description, userId, img, isPrivate)
        VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
        SELECT LAST_INSERT_ID();", keepData);
        keepData.Id = id;
        return keepData;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      return success > 0;
    }

    public Keep EditKeep(Keep editedKeep)
    {
      try
      {
        string query = @"
        UPDATE keeps SET 
        name = @Name,
        views = @Views,
        description = @Description,
        userId = @UserId,
        img = @Img,
        isPrivate = @IsPrivate,
        shares = @Shares,
        keeps = @Keeps

        WHERE id = @Id;
        SELECT * FROM keeps WHERE id = @Id;
        ";
        return _db.QueryFirstOrDefault<Keep>(query, editedKeep);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      };

    }
  }
}