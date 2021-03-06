using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    public IEnumerable<Vault> GetAll(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId", new { userId });
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
        INSERT INTO vaults(name, description, userId)
        VALUES (@Name, @Description, @UserId );
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
    public VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
      try
      {
        var duplicate = _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk 
        WHERE(vaultId = @vaultId AND keepId = @keepId)", vaultKeepData);
        if (duplicate.Count() > 0)
        {
          return null;
        }
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultKeeps(vaultId, keepId, userId)
        VALUES (@VaultId, @KeepId, @UserId );
        SELECT LAST_INSERT_ID();", vaultKeepData);
        vaultKeepData.Id = id;
        return vaultKeepData;
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

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId WHERE(vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
    }

    public bool DeleteFromVaultKeep(int vaultId, int keepId, string userId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, keepId, userId });
      return success > 0;
    }
  }
}