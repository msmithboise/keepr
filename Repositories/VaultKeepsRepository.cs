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
        public IEnumerable<Keep> GetAll(int vaultId)
        {
            return _db.Query<Keep>(@"
                SELECT* FROM vaultkeeps vk
              INNER JOIN keeps k ON k.id = vk.keepId
              WHERE (vaultId = @vaultId)
              ", new { vaultId });
        }

        //GET Vaultkeep by vault id and keep id
        public VaultKeep GetById(int id)
        {
            return _db.Query<VaultKeep>("SELECT * FROM vaultKeeps WHERE id = @id;", new { id }).FirstOrDefault();
        }

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




        //Delete Vaultkeep
        public int Delete(int vaultId, int keepId)
        {
            return _db.Execute("DELETE FROM vaultKeeps WHERE vaultId = @vaultId AND keepId = @keepId;", new { vaultId, keepId });
        }





    }

}