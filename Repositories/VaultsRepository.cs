using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

    public class VaultsRepository
    {
        private IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD VIA SQL

        //GET ALL 
        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM keeps;");
        }

        //GET Vault BY ID
        public Vault GetById(int id)
        {
            return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id }).FirstOrDefault();
        }

        //CREATE Vault
        public Vault Create(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description)
        VALUES (@Name, @Description);
        SELECT LAST_INSERT_ID();", vault
            );
            vault.Id = id;
            return vault;
        }

        //UPDATE Vault
        public Vault Update(Vault vault)
        {
            _db.Execute(@"
      UPDATE vaults SET (name, description) 
      VALUES (@Name, @Description)
      WHERE id = @Id
      ", vault);
            return vault;
        }

        //DELETE Vault
        public Vault Delete(Vault vault)
        {
            _db.Execute("DELETE FROM vaults WHERE id = @Id", vault);
            return vault;
        }



        public IEnumerable<Vault> GetKeepsByUserId(string id)
        {
            return _db.Query<Vault>(@"
        SELECT * FROM uservaults
        INNER JOIN vaults ON vaults.id = uservaults.vaultId
        WHERE userId = @id
      ", new { id });
        }

        //         SELECT* FROM vaultkeeps vk
        //   INNER JOIN keeps k ON k.id = vk.keepId
        //   WHERE (vaultId = 2)


        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
        }


    }

}