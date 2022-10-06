using Library.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class AuthorsRepository
    {
        public List<Authors> GetAllAuthors()
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);

            connection.Open();

            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Authors";

            SqlDataReader dataReader = cmd.ExecuteReader();


            List<Authors> authorList = new List<Authors>();

            while (dataReader.Read())
            {
                authorList.Add(new Authors(
                    Convert.ToInt16(dataReader[0].ToString()),
                    dataReader[1].ToString(),
                    dataReader[2].ToString()
                    ));
            }

            dataReader.Close();
            cmd.Connection.Close();
            connection.Close();


            return authorList;
        }

        public Authors GetAuthorById(int id)
        {
            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);

            connection.Open();

            var cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * FROM Authors WHERE AuthorID = {id}";

            SqlDataReader dataReader = cmd.ExecuteReader();


            dataReader.Read();
            Authors authors = new Authors(Convert.ToInt16(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString());
     

            dataReader.Close();
            cmd.Connection.Close();
            connection.Close();


            return authors;
        }


        public bool PostAuthor(Authors author)
        {

            string connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";


            var connection = new SqlConnection(connectionString);


            string command = $"INSERT INTO Authors VALUES({author.AuthorId}, '{author.FirstName}', '{author.LastName}')";



            try
            {
                connection.Open();


                var cmd = new SqlCommand(command, connection);

                /*cmd.Parameters.Add("@AuthorID", SqlDbType.Int, 4, "AuthorID").Value = author.AuthorId;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 255, "FirstName").Value = author.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 255, "LastName").Value = author.LastName;*/


                cmd.ExecuteNonQuery();
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
