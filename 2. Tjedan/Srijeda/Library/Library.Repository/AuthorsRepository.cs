using Library.Model;
using Library.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{

    public class AuthorRepository : IAuthorRepositoryCommon
    {

        string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var connection = new SqlConnection(connectionString);

            connection.Open();

            try
            {
                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM Author";

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

                List<Author> authorList = new List<Author>();


                while (await dataReader.ReadAsync())
                {
                    authorList.Add(new Author(
                        Convert.ToInt16(dataReader[0].ToString()),
                        dataReader[1].ToString(),
                        dataReader[2].ToString()
                        ));
                }

                dataReader.Close();
                connection.Close();


                return authorList;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {

                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM Author WHERE AuthorID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


                await dataReader.ReadAsync();
                Author author = new Author(Convert.ToInt16(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString());


                dataReader.Close();
                cmd.Connection.Close();
                connection.Close();
                return author;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }


        public async Task<bool> PostAuthorAsync(Author author)
        {
            var connection = new SqlConnection(connectionString);


            string command = "INSERT INTO Author VALUES(@AuthorID, @FirstName, @LastName)";

            try
            {
                connection.Open();


                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = command;

                cmd.Parameters.AddWithValue("@AuthorID",author.AuthorId);
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);


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

        
        public async Task<bool> DeleteAuthorByIdAsync(int id)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();


                var cmd = new SqlCommand("DELETE FROM Author WHERE AuthorID = @AuthorID", connection);

                cmd.Parameters.AddWithValue("@AuthorID", id);


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


        public async Task<bool> UpdateAuthorAsync(int id,Author author)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();


              

                string sql = "UPDATE Author SET FirstName = @FirstName, LastName = @LastName  WHERE AuthorID = @AuthorID";

                
                var cmd = new SqlCommand(sql,connection);

                cmd.Parameters.AddWithValue("@AuthorID", id);
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);


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
