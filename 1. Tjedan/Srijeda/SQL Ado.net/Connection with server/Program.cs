using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Connection_with_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = DESKTOP-MUBQ7TC\\SQLEXPRESS; Database = MonoPraksa; Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);
            

            connection.Open();

            var cmd = new SqlCommand();

            cmd.Connection  = connection;
            cmd.CommandText = "SELECT FirstName,LastName FROM Authors";





            //Write all from author table
            SqlDataReader dataReader = cmd.ExecuteReader();
            Console.WriteLine($"__________________________________________\n");
            Console.WriteLine($"| First Name \t| \t| Last Name \t|\n");
            Console.WriteLine($"__________________________________________\n");
            while (dataReader.Read())
            {
                Console.WriteLine($"| {dataReader["FirstName"]} \t| \t| {dataReader["LastName"]} \t|\n");
            }

            dataReader.Close();


            SqlDataAdapter authorAdapter = new SqlDataAdapter(
              "SELECT * FROM Authors", connection);
            SqlDataAdapter booksAdapter = new SqlDataAdapter(
              "SELECT * FROM Books", connection);

            DataSet booksAndAuthors = new DataSet();

            //Populate dataset
            authorAdapter.Fill(booksAndAuthors, "Authors");
            booksAdapter.Fill(booksAndAuthors, "Books");

            //Add to dataset
            booksAndAuthors.Tables["Books"].Rows.Add(6, 3, "The Haunted Man", 1848, "English","9781532902024");

            DataRelation relation = booksAndAuthors.Relations.Add("BookAuthors",
              booksAndAuthors.Tables["Authors"].Columns["AuthorID"],
              booksAndAuthors.Tables["Books"].Columns["AuthorID"]);


            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("INSERT INTO Books VALUES(11, 4, \'The Haunted Man\', 1848, \'English\', \'9781632902024\')", connection));
                dataAdapter.Fill(new DataSet("Books"));
            }
            catch (Exception)
            {
                
                throw;
            }



            //Write Author ID and Book ID
            foreach (DataRow pRow in booksAndAuthors.Tables["Authors"].Rows)
            {
                Console.WriteLine(pRow["AuthorID"]);
                foreach (DataRow cRow in pRow.GetChildRows(relation))
                    Console.WriteLine($"\t  {cRow["BookID"]}");
            }


            Console.WriteLine();


            foreach (DataRow pRow in booksAndAuthors.Tables["Books"].Rows)
            {
                Console.WriteLine($"{pRow["Title"]} \t{pRow["ISBN"]}");
            }

            authorAdapter.Dispose();
            booksAdapter.Dispose();

            connection.Close();


            Console.ReadKey();

        }
    }
}
