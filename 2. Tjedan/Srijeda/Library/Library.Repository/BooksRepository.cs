using Library.Common;
using Library.Model;
using Library.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Repository
{
    public class BookRepository : IBookRepositoryCommon
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

        public async Task<List<Book>> FindAsync(Paging pager, Filtering filter, Sorting sorting)
        {
            var connection = new SqlConnection(connectionString);

            connection.Open();

            try
            {

                var cmd = new SqlCommand();

                StringBuilder commandString = new StringBuilder($"SELECT * FROM Book WHERE 1=1 ");

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    commandString.AppendLine($"AND Title LIKE @Title");
                }
                if (!string.IsNullOrEmpty(filter.Language))
                {
                    commandString.AppendLine($"AND OriginalLanguage LIKE @Language");
                }

                commandString.AppendLine($"AND PublishYear BETWEEN @YearMin AND @YearMax");
                



                commandString.AppendLine($"ORDER BY {sorting.SortBy} {sorting.SortOrder} ");
                commandString.AppendLine("OFFSET @PageNumber ROWS FETCH NEXT @PageSize ROWS ONLY");







                cmd.Connection = connection;
                cmd.CommandText = commandString.ToString();

                cmd.Parameters.AddWithValue("@PageNumber", pager.PageNumber * pager.PageSize - pager.PageSize);
                cmd.Parameters.AddWithValue("@PageSize", pager.PageSize);
                cmd.Parameters.AddWithValue("@Title", "%"+filter.Title+"%");
                cmd.Parameters.AddWithValue("@Language", "%" + filter.Language + "%");
                cmd.Parameters.AddWithValue("@YearMin", filter.YearMin);
                cmd.Parameters.AddWithValue("@YearMax", filter.YearMax);



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
                cmd.CommandText = $"SELECT * FROM Book WHERE BookID = @BookID";
                cmd.Parameters.AddWithValue("BookID",id);

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

                string command = $"INSERT INTO Book VALUES(@BookID, @AuthorId, @Title, @PublishYear, @OriginalLanguage, @ISBN)";
                var cmd = new SqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@BookID",book.BookId);
                cmd.Parameters.AddWithValue("@AuthorID",book.AuthorId);
                cmd.Parameters.AddWithValue("@Title",book.Title);
                cmd.Parameters.AddWithValue("@PublishYear",book.PublishYear);
                cmd.Parameters.AddWithValue("@OriginalLanguage",book.OriginalLanguage);
                cmd.Parameters.AddWithValue("@ISBN",book.ISBN);




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
                var cmd = new SqlCommand($"DELETE FROM Book WHERE BookID = @BookId", connection);
                cmd.Parameters.AddWithValue("BookID",id);


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
                

                cmd.CommandText = $"UPDATE Book SET Title = @Title, PublishYear = @PublishYear, OriginalLanguage = @OriginalLanguage, ISBN = @ISBN WHERE BookID = @BookID";

                cmd.Parameters.AddWithValue("@BookID", book.BookId);
                cmd.Parameters.AddWithValue("@Title",book.Title);
                cmd.Parameters.AddWithValue("@PublishYear",book.PublishYear);
                cmd.Parameters.AddWithValue("@OriginalLanguage",book.OriginalLanguage);
                cmd.Parameters.AddWithValue("@ISBN",book.ISBN);



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
