using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Common;

namespace Library.Model
{
    public class AuthorRest : IAuthorRestCommon
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int NumberOfBooks { get; set; }

        public AuthorRest(int authorid, string firstname, string lastname)
        {
            AuthorId = authorid;
            FirstName = firstname;
            LastName = lastname;
        }

        public AuthorRest()
        {
            AuthorId = 0;
            FirstName = "";
            LastName = "";
        }

    }
}
