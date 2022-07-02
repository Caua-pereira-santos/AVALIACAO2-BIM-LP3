using Microsoft.Data.Sqlite;

namespace A.Database;

class DatabaseSetup
{
    private DatabaseConfig databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateTableProduct();
    }

    private void CreateTableProduct()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
        
        CREATE TABLE IF NOT EXISTS Products(id int not null primary key, name varchar(100) not null, price varchar (100) not null, active varchar(100) not null);
        
        ";
        command.ExecuteNonQuery();
        connection.Close();

    }
}