using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MinorProject1
{
    public class DataAccess
    {
        private string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Gets a list of all tables in the database
        public List<string> GetTableNames()
        {
            List<string> tables = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables.Add(reader["TABLE_NAME"].ToString());
                    }
                }
            }
            return tables;
        }

        // Gets the total number of records in a specific table
        public int GetRowCount(string tableName)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Note: Direct string injection for table names is used here for simplicity in a school project
                string query = $"SELECT COUNT(*) FROM {tableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }

        // Gets all column names for a specific table (useful for asking the user what to insert)
        public List<string> GetColumnNames(string tableName)
        {
            List<string> columns = new List<string>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tableName", tableName);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader["COLUMN_NAME"].ToString());
                    }
                }
            }
            return columns;
        }

        // Gets all data from a table and prints it directly to the console
        public void GetAllRecords(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM {tableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Print column headers
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-15} | ");
                    }
                    Console.WriteLine("\n" + new string('-', 50));

                    // Print data rows
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i].ToString(),-15} | ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        // Inserts a new record using a dictionary of column names and user inputs
        public void InsertRecord(string tableName, Dictionary<string, string> columnValues)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string columns = string.Join(", ", columnValues.Keys);
                string parameters = string.Join(", ", columnValues.Keys).Replace(", ", ", @");
                parameters = "@" + parameters; // Fix first parameter formatting

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";
                SqlCommand cmd = new SqlCommand(query, conn);

                foreach (var kvp in columnValues)
                {
                    cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Updates a specific column for a specific record
        public void UpdateRecord(string tableName, string primaryKeyColumn, string primaryKeyValue, string updateColumn, string updateValue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = $"UPDATE {tableName} SET {updateColumn} = @updateValue WHERE {primaryKeyColumn} = @primaryKeyValue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@updateValue", updateValue);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Deletes a specific record
        public void DeleteRecord(string tableName, string primaryKeyColumn, string primaryKeyValue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM {tableName} WHERE {primaryKeyColumn} = @primaryKeyValue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}