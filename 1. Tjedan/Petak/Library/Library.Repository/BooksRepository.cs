using Library.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BooksRepository
    {
        public async Task<List<Books>> GetAllBooksAsync()
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);



            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Books";

            connection.Open();

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<Books> bookList = new List<Books>();


            while (await dataReader.ReadAsync())
            {
                bookList.Add(new Books(
                    Convert.ToInt16(dataReader[0].ToString()),
                    Convert.ToInt16(dataReader[1].ToString()),
                    dataReader[2].ToString(),
                    Convert.ToInt16(dataReader[3].ToString()),
                    dataReader[4].ToString(),
                    dataReader[5].ToString()
                    ));
            }

            dataReader.Close();
            cmd.Connection.Close();
            connection.Close();


            return bookList;
        }

        public async Task<Books> GetBookByIdAsync(int id)
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);

            connection.Open();

            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * FROM Books WHERE BookID = {id}";

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


            await dataReader.ReadAsync();
            Books books = new Books(
                    Convert.ToInt16(dataReader[0].ToString()),
                    Convert.ToInt16(dataReader[1].ToString()),
                    dataReader[2].ToString(),
                    Convert.ToInt16(dataReader[3].ToString()),
                    dataReader[4].ToString(),
                    dataReader[5].ToString()
                    );


            dataReader.Close();
            cmd.Connection.Close();
            connection.Close();


            return books;
        }


        public async Task<bool> PostBookAsync(Books book)
        {

            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";


            var connection = new SqlConnection(connectionString);


            string command = $"INSERT INTO Books VALUES({book.BookId}, {book.AuthorId}, '{book.Title}', {book.PublishYear}, '{book.OriginalLanguage}', '{book.ISBN}')";



            try
            {
                connection.Open();


                var cmd = new SqlCommand(command, connection);


                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
                throw;
            }
        }


        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();


                var cmd = new SqlCommand($"DELETE FROM Books WHERE BookID = {id}", connection);


                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
                throw;
            }
        }


        public async Task<bool> UpdateBookAsync(int id, Books book)
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $"SELECT * FROM Books WHERE BookID = {id}";

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


                await dataReader.ReadAsync();

                Books booksData = new Books(
                    Convert.ToInt16(dataReader[0].ToString()),
                    Convert.ToInt16(dataReader[1].ToString()),
                    dataReader[2].ToString(),
                    Convert.ToInt16(dataReader[3].ToString()),
                    dataReader[4].ToString(),
                    dataReader[5].ToString()
                    );

                dataReader.Close();

                /*if (author.FirstName == null)
                {
                    author.FirstName = authorData.FirstName;
                }
                else if (author.LastName == null)
                {
                    author.LastName = authorData.LastName;
                }*/


                cmd.CommandText = $"UPDATE Books SET " +
                    $"Title = '{book.Title}', " +
                    $"PublishYear = {book.PublishYear}," +
                    $"OriginalLanguage = {book.OriginalLanguage}" +
                    $"ISBN = {book.ISBN}" +
                    $"WHERE BookID = {id}";


                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
                throw;
            }
        }
    }
}
