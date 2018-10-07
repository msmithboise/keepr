using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

    public class KeepsRepository
    {
        private IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD VIA SQL

        //GET ALL 
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps;");
        }

        //GET BURGER BY ID
        public Keep GetById(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id }).FirstOrDefault();
        }

        //CREATE BURGER
        public Keep Create(Keep keep)
        {
            int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description)
        VALUES (@Name, @Description);
        SELECT LAST_INSERT_ID();", keep
            );
            keep.Id = id;
            return keep;
        }

        //UPDATE BURGER
        public Keep Update(Keep keep)
        {
            _db.Execute(@"
      UPDATE keeps SET (name, description) 
      VALUES (@Name, @Description)
      WHERE id = @Id
      ", keep);
            return keep;
        }

        //DELETE BURGER
        public Keep Delete(Keep keep)
        {
            _db.Execute("DELETE FROM keeps WHERE id = @Id", keep);
            return keep;
        }



        public IEnumerable<Keep> GetKeepsByUserId(string id)
        {
            return _db.Query<Keep>(@"
        SELECT * FROM userkeeps
        INNER JOIN keeps ON keeps.id = userkeeps.keepId
        WHERE userId = @id
      ", new { id });
        }

        //         SELECT* FROM vaultkeeps vk
        //   INNER JOIN keeps k ON k.id = vk.keepId
        //   WHERE (vaultId = 2)


        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
        }


    }

}