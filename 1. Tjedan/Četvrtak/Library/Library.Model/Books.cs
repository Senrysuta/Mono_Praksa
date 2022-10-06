using Library.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class Books : IBooksCommon
    {
        public int BookId { get; set; }
        public string AuthorId { get; set; }
        public  string Title { get; set; }
        public int PublishYear { get; set; }
        public string OriginalLanguage { get; set; }
        public string ISBN { get; set; }

        public Books(int bookid, string authorid, string title, int publishyear, string orlang, string isbn)
        {
            BookId = bookid;
            AuthorId = authorid;
            Title = title;
            PublishYear = publishyear;
            OriginalLanguage = orlang;
            ISBN = isbn;
        }




    }
}
