using Library.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class Authors : IAuthorsCommon
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Authors(int id, string firstName, string lastName)
        {
            AuthorId = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
