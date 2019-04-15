using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public Vault FindById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id", new { id });
    }

    public Vault CreateVault(Vault vaultData)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults(title, description, userId)
        VALUES (@Title, @Description, @UserId );
        SELECT LAST_INSERT_ID();", vaultData);
        vaultData.Id = id;
        return vaultData;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}