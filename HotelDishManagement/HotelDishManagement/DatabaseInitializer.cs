using Microsoft.Data.Sqlite;

namespace HotelDishManagement
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            // Connection string to the SQLite database
            string connectionString = "Data Source=Database/hotel.db;";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // SQL query to create the Dishes table
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Dishes (
                    Number INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Price REAL NOT NULL,
                    Introduction TEXT,
                    Category TEXT NOT NULL,
                    Type TEXT NOT NULL
                );
            ";

            using var command = new SqliteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();

            // Optionally insert some default data (if needed)
            string insertQuery = @"
                INSERT OR IGNORE INTO Dishes (Number, Name, Price, Introduction, Category, Type)
                VALUES
                (1, 'Sushi', 12.99, 'Japanese delicacy', 'Asian Food', 'Meat'),
                (2, 'Pizza', 8.99, 'Cheesy Italian classic', 'Fast Food', 'Vegetarian'),
                (3, 'Burger', 9.49, 'American-style classic', 'Fast Food', 'Meat');
            ";

            using var insertCommand = new SqliteCommand(insertQuery, connection);
            insertCommand.ExecuteNonQuery();

            connection.Close();

            System.Console.WriteLine("Database initialized successfully!");
        }
    }
}
