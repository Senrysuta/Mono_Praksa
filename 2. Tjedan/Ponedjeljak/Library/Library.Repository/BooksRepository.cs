using Library.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BookRepository
    {
        string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

        public async Task<List<Book>> GetAllBooksAsync()
        {

            var connection = new SqlConnection(connectionString);
            connection.Open();


            try
            {
                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM Book";


                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

                List<Book> bookList = new List<Book>();


                while (await dataReader.ReadAsync())
                {
                    bookList.Add(new Book(
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
            catch (Exception)
            {
                connection.Close();
                throw;
            }     
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {

            var connection = new SqlConnection(connectionString);

            connection.Open();

            try
            {
                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $"SELECT * FROM Book WHERE BookID = {id}";

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


                await dataReader.ReadAsync();
                Book book = new Book(
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


                return book;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }




        }


        public async Task<bool> PostBookAsync(Book book)
        {

            var connection = new SqlConnection(connectionString);
            connection.Open();


            try
            {

                string command = $"INSERT INTO Book VALUES({book.BookId}, {book.AuthorId}, '{book.Title}', {book.PublishYear}, '{book.OriginalLanguage}', '{book.ISBN}')";
                var cmd = new SqlCommand(command, connection);


                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
                throw;
            }
        }


        public async Task<bool> DeleteBookByIdAsync(int id)
        {

            var connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                var cmd = new SqlCommand($"DELETE FROM Book WHERE BookID = {id}", connection);


                await cmd.ExecuteNonQueryAsync();
                cmd.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
                throw;
            }
        }


        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
           

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $"SELECT * FROM Book WHERE BookID = {id}";

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


                await dataReader.ReadAsync();

                Book booksData = new Book(
                    Convert.ToInt16(dataReader[0].ToString()),
                    Convert.ToInt16(dataReader[1].ToString()),
                    dataReader[2].ToString(),
                    Convert.ToInt16(dataReader[3].ToString()),
                    dataReader[4].ToString(),
                    dataReader[5].ToString()
                    );

                dataReader.Close();


                cmd.CommandText = $"UPDATE Book SET " +
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
            catch (Exception)
            {
                connection.Close();
                return false;
                throw;
            }
        }
    }
}
