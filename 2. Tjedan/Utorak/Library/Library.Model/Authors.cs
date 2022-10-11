using Library.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Author  : IAuthorCommon
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(int id, string firstName, string lastName)
        {
            AuthorId = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Author()
        {
            this.AuthorId = 0;
            this.FirstName = "";
            this.LastName = "";
        }
    }
}
