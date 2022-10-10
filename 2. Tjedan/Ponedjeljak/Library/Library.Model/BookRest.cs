﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookRest : IBookRest
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public string OriginalLanguage { get; set; }
        public string ISBN { get; set; }

        public BookRest(int bookid, int authorid, string title, int publishyear, string orlang, string isbn)
        {
            BookId = bookid;
            AuthorId = authorid;
            Title = title;
            PublishYear = publishyear;
            OriginalLanguage = orlang;
            ISBN = isbn;
        }

        public BookRest()
        {
            BookId = 0;
            AuthorId = 0;
            Title = "";
            PublishYear = 0;
            OriginalLanguage = "";
            ISBN = "";
        }

    }
}
