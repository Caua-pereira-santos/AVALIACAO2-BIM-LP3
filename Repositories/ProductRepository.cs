using A.Models;
using A.Database;
using Microsoft.Data.Sqlite;


namespace A.Repositories;

class ProductRepository
{
   // private readonly DatabaseConfig _databaseConfig;

   public ProductRepository(DatabaseConfig databaseConfig)
   {
    _databaseConfig = databaseConfig;
   }

   public Product Save(Product product)
   {
     var connection = new SqliteConnection(_databaseConfig.ConnectionString);
     connection.Open();

     connection.Execute("INSERT INTO Products VALUES (@Id, @Name, @Price, @Active)", product);

     connection.Close();

     return product;
   }

   public void Delete(int id)
   {
     var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    connection.Execute("DELETE FROM Products WHERE id = @Id;", new {Id = @id});

    connection.Close();
   }

   public void Enable(int id)
   {

   }

   public IEnumerable<Product> GetAll()
   {
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    var products = connection.Query<Product>("SELECT * FROM Products");

    return products;
   }

   public Product GetById(int id)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Products WHERE id = $id;";
    command.Parameters.AddWithValue("$id", id);

    var reader = command.ExecuteReader();
    reader.Read();

    var computer = ReaderToProduct(reader);

    connection.Close();
    return computer;
}

public bool ExitsById(int id)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    var result = connection.ExecuteScalar<Boolean>("SELECT COUNT(id) FROM Products WHERE id=@id;", new {Id = @id});

    return result;
}

private Product ReaderToComputer(SqliteDataReader reader)
{
    var computer = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

    return product;
}
}