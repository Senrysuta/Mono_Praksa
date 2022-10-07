using Library.Common;
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
    public class AuthorsRepository : IAuthorsRepositoryCommon
    {
        string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";
        public async Task<List<Authors>> GetAllAuthorsAsync()
        {
            var connection = new SqlConnection(connectionString);

           

            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Authors";

            connection.Open();

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<Authors> authorList = new List<Authors>();


            while (await dataReader.ReadAsync())
            {
                authorList.Add(new Authors(
                    Convert.ToInt16(dataReader[0].ToString()),
                    dataReader[1].ToString(),
                    dataReader[2].ToString()
                    ));
            }

            dataReader.Close();
            connection.Close();


            return authorList;
        }

        public async Task<Authors> GetAuthorByIdAsync(int id)
        {
            var connection = new SqlConnection(connectionString);

            connection.Open();

            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Authors WHERE AuthorID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


            await dataReader.ReadAsync();
            Authors authors = new Authors(Convert.ToInt16(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString());
     

            dataReader.Close();
            cmd.Connection.Close();
            connection.Close();


            return authors;
        }


        public async Task<bool> PostAuthorAsync(Authors author)
        {
            var connection = new SqlConnection(connectionString);


            string command = "INSERT INTO Authors VALUES(@AuthorID, @FirstName, @LastName)";

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
            catch (Exception ex)
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


                var cmd = new SqlCommand("DELETE FROM Authors WHERE AuthorID = @AuthorID", connection);

                cmd.Parameters.AddWithValue("@AuthorID", id);


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


        public async Task<bool> UpdateAuthorAsync(int id,Authors author)
        {

            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                var cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = $"SELECT * FROM Authors WHERE AuthorID = @AuthorID";
                cmd.Parameters.AddWithValue("@AuthorID", id);

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();


                await dataReader.ReadAsync();

                Authors authorData = new Authors(Convert.ToInt16(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString());


                dataReader.Close();

                if (author.FirstName == null)
                {
                    author.FirstName = authorData.FirstName;
                }
                else if (author.LastName == null)
                {
                    author.LastName = authorData.LastName;
                }


                cmd.CommandText = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName  WHERE AuthorID = @AuthorID";

                cmd.Parameters.AddWithValue("@AuthorID", author.AuthorId);
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);


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
