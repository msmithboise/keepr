using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

    public class VaultKeepsRepository
    {
        private IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD VIA SQL

        //GET ALL VaultKeeps
        public IEnumerable<VaultKeep> GetAll(string userId)
        {
            return _db.Query<VaultKeep>("SELECT * FROM vaultKeeps WHERE userId = @userId;", new { userId });
        }

        // //GET Vaultkeep by vault id and keep id
        // public VaultKeep GetById(int id)
        // {
        //     return _db.Query<VaultKeep>("SELECT * FROM vaultKeeps WHERE id = @id;", new { id }).FirstOrDefault();
        // }

        //CREATE Vault
        public VaultKeep Create(VaultKeep vaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultKeeps (keepId, vaultId, userId)
        VALUES (@KeepId, @VaultId, @UserId);
        SELECT LAST_INSERT_ID();", vaultKeep
            );
            vaultKeep.Id = id;
            return vaultKeep;
        }

        //     //UPDATE Vault
        //     public VaultKeep Update(VaultKeep vaultKeep)
        //     {
        //         _db.Execute(@"
        //   UPDATE vaultKeeps SET (id, vaultId, keepId, UserId) 
        //   WHERE id = @Id, @VaultId, @UserId, KeepId
        //   ", vaultKeep);
        //         return vaultKeep;
        //     }

        //     //DELETE Vault
        //     public VaultKeep Delete(VaultKeep vaultKeep)
        //     {
        //         _db.Execute("DELETE FROM vaultKeeps WHERE id = @Id", vaultKeep);
        //         return vaultKeep;
        //     }



        //     public IEnumerable<VaultKeep> GetKeepsByUserId(string id)
        //     {
        //         return _db.Query<VaultKeep>(@"
        //     SELECT * FROM uservaultKeeps
        //     INNER JOIN vaultKeeps ON vaults.id = uservaultKeepss.vaultKeepId
        //     WHERE userId = @id
        //   ", new { id });
        //     }

        //     //         SELECT* FROM vaultkeeps vk
        //     //   INNER JOIN keeps k ON k.id = vk.keepId
        //     //   WHERE (vaultId = 2)


        //     public int Delete(int id)
        //     {
        //         return _db.Execute("DELETE FROM vaultKeeps WHERE id = @id", new { id });
        //     }


    }

}