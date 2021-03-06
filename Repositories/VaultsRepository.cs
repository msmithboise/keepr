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

        //GET ALL Vaults for the logged in user
        public IEnumerable<Vault> GetAll(string userId)
        {
            return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId;", new { userId });
        }

        //GET Vault BY user ID
        public Vault GetById(int id)
        {
            return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id }).FirstOrDefault();
        }

        //CREATE Vault
        public Vault Create(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, isPrivate, keeps, shares, views, userId)
        VALUES (@Name, @Description, @IsPrivate, @Keeps, @Shares, @Views, @UserId);
        SELECT LAST_INSERT_ID();", vault
            );
            vault.Id = id;
            return vault;
        }

        //UPDATE Vault
        public Vault EditVault(int id, Vault vault)
        {

            return _db.QueryFirstOrDefault<Vault>($@"UPDATE vaults 
            SET 
            name = @Name, 
            description = @Description,
            isPrivate = @IsPrivate,
            keeps = @Keeps,
            shares = @Shares,
            views = @Views
            WHERE id = {id};
            SELECT * FROM Vaults WHERE Id = {id};", vault);
        }

        //DELETE Vault
        public Vault DeleteVault(Vault vault)
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
            return _db.Execute($"DELETE FROM vaultKeeps WHERE id = {id}");
        }


    }

}