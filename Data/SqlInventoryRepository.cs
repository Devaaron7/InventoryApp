using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public class SqlInventoryRepository : BaseRepository, IInventoryRepository
    {
        public SqlInventoryRepository(string conn) : base(conn) { }

        public void AddItem(InventoryItem item)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO InventoryItems (Name, Quantity, Category) VALUES (@name, @quantity, @category)", conn);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.ExecuteNonQuery();
        }

        public List<InventoryItem> GetItems()
        {
            var list = new List<InventoryItem>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM InventoryItems", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new InventoryItem
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    Category = reader["Category"].ToString()
                });
            }
            return list;
        }
    }
}
