using Dapper;
using Infra.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class TodoItemRepository
    {
        private string ConnectionString = "Server=tcp:infnet-server.database.windows.net,1433;Initial Catalog=infnet-database;Persist Security Info=False;User ID=rbcruz;Password=123456789#A;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public List<TodoItem> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Tbl_Todo_Item";
                return connection.Query<TodoItem>(sql).ToList();
            }
        }

        public TodoItem GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM Tbl_Todo_Item where id = @id";
                return connection.QueryFirstOrDefault<TodoItem>(sql, new { id = id });
            }

        }

        public int Save(TodoItem item)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var sql = @"    INSERT INTO Tbl_Todo_Item (AssignedFor, Status, Name, Description)
                                                   Values (@AssignedFor, @Status, @Name, @Description);
                                       SELECT @@IDENTITY;
                            ";

                var lastId = connection.ExecuteScalar<int>(sql, item);
                return lastId;

                // OU ASSIM
                
                //var sql =  @"    INSERT INTO Tbl_Todo_Item (AssignedFor, Status, Name, Description)
                //                                    Values (@AssignedFor, @Status, @Name, @Description);
                //            ";

                //connection.Execute(sql, item);

                //var sql2 = "SELECT MAX(ID) FROM Tbl_Todo_Item";

                //var lastId = connection.ExecuteScalar<int>(sql2);

                //item.Id = lastId;
            }
        }

    }
}
