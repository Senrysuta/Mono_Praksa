using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Common
{
    public interface IAuthorRestCommon
    {
        int AuthorId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
