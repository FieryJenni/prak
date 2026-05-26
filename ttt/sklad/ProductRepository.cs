using MySql.Data.MySqlClient;
using sklad.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace sklad.Repositories
{
    public class ProductRepository
    {
        private readonly DB _db;
        public ProductRepository()
        {
            _db = new DB();
        }

        public List<Product> GetAll(string search = "")
        {
            List<Product> list = new List<Product>();
            string query = "SELECT id, name, article, price, quantity FROM products WHERE 1=1";
            if (!string.IsNullOrEmpty(search))
                query += " AND (name LIKE @search OR article LIKE @search)";
            query += " ORDER BY name";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            if (!string.IsNullOrEmpty(search))
                cmd.Parameters.Add("@search", MySqlDbType.VarChar).Value = "%" + search + "%";
            _db.openConnection();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Article = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Quantity = reader.GetInt32(4)
                    });
                }
            }
            _db.closeConnection();
            return list;
        }

        public Product GetById(int id)
        {
            Product product = null;
            string query = "SELECT id, name, article, price, quantity FROM products WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            _db.openConnection();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Article = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Quantity = reader.GetInt32(4)
                    };
                }
            }
            _db.closeConnection();
            return product;
        }

        public void Add(Product product)
        {
            string query = "INSERT INTO products (name, article, price, quantity) VALUES (@name, @article, @price, @quantity)";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@article", MySqlDbType.VarChar).Value = product.Article;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = product.Price;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            _db.openConnection();
            cmd.ExecuteNonQuery();
            _db.closeConnection();
        }

        public void Update(Product product)
        {
            string query = "UPDATE products SET name=@name, article=@article, price=@price, quantity=@quantity WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = product.Id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@article", MySqlDbType.VarChar).Value = product.Article;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = product.Price;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            _db.openConnection();
            cmd.ExecuteNonQuery();
            _db.closeConnection();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM products WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            _db.openConnection();
            cmd.ExecuteNonQuery();
            _db.closeConnection();
        }
    }
}