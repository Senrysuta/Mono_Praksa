using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Common;

namespace Library.Model
{
    public class AuthorsRest : IAuthorsRestCommon
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
