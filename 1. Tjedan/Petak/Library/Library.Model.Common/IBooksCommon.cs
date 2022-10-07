using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common.Common
{
    public interface IBooksCommon
    {
        int BookId { get; set; }
        int AuthorId { get; set; }
        string Title { get; set; }
        int PublishYear { get; set; }
        string OriginalLanguage { get; set; }
        string ISBN { get; set; }

    }
}
