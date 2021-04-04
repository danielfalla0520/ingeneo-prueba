using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class BookResponse : CodeResponse
    {
        public List<Model.Entities.BookEntity> bookEntity { get; set; }
    }
}
